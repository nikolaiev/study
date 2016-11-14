	
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.6.1055.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
//link to Windows.Forms
.assembly extern System.Windows.Forms 
{ 
.publickeytoken = (B7 7A 5C 56 19 34 E0 89)
.ver 4:0 : 0 : 0 
}
.assembly HelloProgram
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module HelloProgram.exe
// MVID: {55641CC1-75CA-4241-998B-E53EE94A5851}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x02820000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit HelloProgram.Program
       extends [mscorlib]System.Object
{
  .method private hidebysig static void Main(string[] args) cil managed 
	{ 
		.entrypoint 
		.maxstack 8 
		ldstr "CIL is way cool" 
		call valuetype [System.Windows.Forms] System.Windows.Forms.DialogResult  
		[System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string) 
		pop 
		ret 
	}

} // end of class HelloProgram.Program


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file E:\7sem\тарнавский\1лаб\HelloProgram.res
