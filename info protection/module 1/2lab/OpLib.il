.assembly OpLib {.ver 2:0:0:0 }	

.class public Operation
{
	.method public static int32 GetNumber(string varName)
	{
		//Загружаем в стек текст приглашения на ввод числа
		ldarg varName
		//Выводим приглашение на экран
		call void [mscorlib]System.Console::Write(string)
		//Ожидаем ввода числа
		call string [mscorlib]System.Console::ReadLine()
		//Преобразуем (если возможно) введенное значение в число
		call int32 [mscorlib]System.Int32::Parse(string)
		//Возвращаем полученное число
		ret
	}

	.method public static int32 Sum(int32 x, int32 y)
	{
		ldarg x //Загружаем в стек аргумент x
		ldarg y //Загружаем в стек аргумент y
		add // Находим сумму и помещаем результат в стек
		ret //Возвращаем результат
	}

	.method public static void SumPrint(int32 x, int32 y, int32 z)
	{
		ldstr "{0} + {1} = {2}" //Задаем строку формата для вывода данных
		ldarg x //Загружаем в стек аргумент x
		box int32 //Упаковываем x (нужно для WriteLine)
		ldarg y //Загружаем в стек аргумент y
		box int32 //Упаковываем y
		ldarg z //Загружаем в стек аргумент z
		box int32 //Упаковываем z
		//Выводим отформатированную строку
		call void [mscorlib]System.Console::WriteLine(string, object, object, object)
		ret //Выход из функции
	}
	
	.method public static int32 Sub(int32 x, int32 y)
	{
		ldarg x //Загружаем в стек аргумент х
		ldarg y //Загружаем в стек аргумент y
		sub		//Отнимаем y от х и помещаем результат в стек
		ret		//Возвращаес результат
	}
	
	.method public static int32 Mul(int32 x, int32 y)
	{
		ldarg x //Загружаем в стек аргумент х
		ldarg y //Загружаем в стек аргумент y
		mul		//Множим х на y и помещаем результат в стек
		ret		//Возвращаес результат
	}
	
	.method public static int32 Div(int32 x, int32 y)
	{
		ldarg x //Загружаем в стек аргумент х
		ldarg y //Загружаем в стек аргумент y
		div		//Делим х на y и помещаем результат в стек
		ret		//Возвращаес результат
	}
	
	.method public static void FormulaPrint(int32 d,  int32 z)
	{
		ldstr "{0}={1}" //Задаем строку формата для вывода данных
	
		ldarg z //Загружаем в стек аргумент х
		box int32 //Упаковываем x(нужно для WriteLine)		
	
		ldarg d //Загружаем в стек аргумент y
		box int32 //Упаковываем y(нужно для WriteLine)	
			
		//Выводим отформатирвоанную строку
		call void [mscorlib]System.Console::WriteLine(string,object,object)
	
		ret//Выход из функции
	}
	
	.method public void .ctor() //Конструктор класса
	{
		.maxstack 1
		ldarg.0
		call instance void [mscorlib]System.Object::.ctor()
		ret
	}
}