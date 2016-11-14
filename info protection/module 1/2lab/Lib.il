.assembly Lib {.ver 2:0:0:0 }	

.assembly extern OpLib{.ver 2:0:0:0}

// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}

.class public Lab2
{
	.method public static int32 Left(int32 a,int32 b)
	{
	//;Трижды загружаем в стек локальную переменную а
		.locals init (int32 a,int32 b)
		
		ldloc a
		stloc a //Сохраняем значение операнда 1 в локальной переменной a
		ldloc b
		stloc b //Сохраняем значение операнда 2 в локальной переменной b
		
		ldloc a //;[a,_]
		ldloc a //;[a,a,_]
		ldloc a //;[a,a,a,_]
		
		//;Находим а в кубе
		call int32 [OpLib]Operation::Mul(int32 a, int32 a) 
		//;[a^2,a,_]
		call int32 [OpLib]Operation::Mul(int32 a, int32 a) 
		//;[a^3,_]
		
		//;Трижды загружаем в стек локальную переменную b
		ldloc b //;[b,_]
		ldloc b //;[b,b,_]
		ldloc b //;[b,b,b,a^3]
		
		//;Находим а в кубе
		call int32 [OpLib]Operation::Mul(int32 b, int32 b) 
		//;[b^2,b,_]
		call int32 [OpLib]Operation::Mul(int32 b, int32 b) 
		//;[b^3,a^3,_]
		
		call int32 [OpLib]Operation::Sub(int32 a, int32 b)
		ret
		
	}
	.method public static int32 Right (int32 a,int32 b)
	{
	
		.locals init (int32 a,int32 b)
		
		ldloc a
		stloc a //Сохраняем значение операнда 1 в локальной переменной a
		ldloc b
		stloc b //Сохраняем значение операнда 2 в локальной переменной b
		
		//;Дважды загружаем в стек локальную переменную а
		ldloc a //;[a,_]
		ldloc a //;[a,a,_]
		
		//;Находим а в квадрате
		call int32 [OpLib]Operation::Mul(int32 a, int32 a) 
		//;[a^2,_]
		
		//;Заносим число а в стек
		ldloc a //;[a,a^2,_]
		ldloc b //;[b,a,a^2,_]
		call int32 [OpLib]Operation::Mul(int32 a, int32 b) 
		//;[a*b,a^2,_]
		ldloc b 
		ldloc b 
		//;[b,b,a*b,a^2,_]
		call int32 [OpLib]Operation::Mul(int32 b, int32 b) 
		//;[b^2,a*b,a^2,_]
		call int32 [OpLib]Operation::Sum(int32 a, int32 b)
		//;[b^2+a*b,a^2,_]
		
		call int32 [OpLib]Operation::Sum(int32 a, int32 b)
		//;[b^2+a*b+a^2,_]
		
		ldloc a
		ldloc b
		//;[b,a,b^2+a*b+a^2,_]
		call int32 [OpLib]Operation::Sub(int32 a, int32 b)
		//;[a-b,b^2+a*b+a^2,_]
		call int32 [OpLib]Operation::Mul(int32 a, int32 b) 
		//;[(a-b)*(b^2+a*b+a^2),_]
		
		ret
	}
	.method public void .ctor() //Конструктор класса
	{
		.maxstack 1
		ldarg.0
		call instance void [mscorlib]System.Object::.ctor()
		ret
	}
}