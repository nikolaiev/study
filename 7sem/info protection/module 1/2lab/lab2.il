.assembly extern Lib{.ver 2:0:0:0}
.assembly extern OpLib{.ver 2:0:0:0}
.assembly Lab2Assemly //Определение текущей сборки
{
	.ver 2:0:0:0 //Номер версии сборки
}

//a3-b3 = (a-b)(a2+ab+b2)
	.method static void Main() //Главный метод программы
	{
		//Объявляем локальные переменные
		.locals init (int32 a, //операнд1
					  int32 b, //операнд2
					  int32 z,
					  int32 d) //результат операции
		//			  class [OpLib]Operation obj)
					  

				  
		ldstr "a=" //Загружаем в стек текст приглашения на ввод операнда 1
		call int32 [OpLib]Operation::GetNumber(string) //Получаем значение операнда 1
		stloc a //Сохраняем значение операнда 1 в локальной переменной a
	
		ldstr "b=" //Загружаем в стек текст приглашения на ввод операнда 2
		call int32 [OpLib]Operation::GetNumber(string) //Получаем значение операнда 2
		stloc b //Сохраняем значение операнда 1 в локальной переменной b
		
		ldloc a //Загружаем в стек локальную переменную x
		ldloc b //Загружаем в стек локальную переменную z
		call int32 [Lib]Lab2::Right(int32 a,int32 b)
		stloc d
		
		ldloc a //Загружаем в стек локальную переменную x
		ldloc b //Загружаем в стек локальную переменную z
		call int32 [Lib]Lab2::Left(int32 a,int32 b)
		stloc z
		
		
		ldloc d //Загружаем в стек локальную переменную x
		ldloc z //Загружаем в стек локальную переменную z
		call void [OpLib]Operation::FormulaPrint(int32 d, int32 z)
		

		.entrypoint //Текущий метод есть точкой входа
		ret //Возврат из метода
	}


