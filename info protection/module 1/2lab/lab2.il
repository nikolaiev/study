.assembly extern Lib{.ver 2:0:0:0}
.assembly extern OpLib{.ver 2:0:0:0}
.assembly Lab2Assemly //����������� ������� ������
{
	.ver 2:0:0:0 //����� ������ ������
}

//a3-b3 = (a-b)(a2+ab+b2)
	.method static void Main() //������� ����� ���������
	{
		//��������� ��������� ����������
		.locals init (int32 a, //�������1
					  int32 b, //�������2
					  int32 z,
					  int32 d) //��������� ��������
		//			  class [OpLib]Operation obj)
					  

				  
		ldstr "a=" //��������� � ���� ����� ����������� �� ���� �������� 1
		call int32 [OpLib]Operation::GetNumber(string) //�������� �������� �������� 1
		stloc a //��������� �������� �������� 1 � ��������� ���������� a
	
		ldstr "b=" //��������� � ���� ����� ����������� �� ���� �������� 2
		call int32 [OpLib]Operation::GetNumber(string) //�������� �������� �������� 2
		stloc b //��������� �������� �������� 1 � ��������� ���������� b
		
		ldloc a //��������� � ���� ��������� ���������� x
		ldloc b //��������� � ���� ��������� ���������� z
		call int32 [Lib]Lab2::Right(int32 a,int32 b)
		stloc d
		
		ldloc a //��������� � ���� ��������� ���������� x
		ldloc b //��������� � ���� ��������� ���������� z
		call int32 [Lib]Lab2::Left(int32 a,int32 b)
		stloc z
		
		
		ldloc d //��������� � ���� ��������� ���������� x
		ldloc z //��������� � ���� ��������� ���������� z
		call void [OpLib]Operation::FormulaPrint(int32 d, int32 z)
		

		.entrypoint //������� ����� ���� ������ �����
		ret //������� �� ������
	}


