
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.6.1055.0
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly Program
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.

  // --- The following custom attribute is added automatically, do not uncomment -------
  //  .custom instance void [mscorlib]System.Diagnostics.DebuggableAttribute::.ctor(valuetype [mscorlib]System.Diagnostics.DebuggableAttribute/DebuggingModes) = ( 01 00 07 01 00 00 00 00 ) 

  .hash algorithm 0x00008004
  .ver 0:0:0:0
}
.module Program.exe
// MVID: {9911BD5B-6444-45BB-8C6B-2C6D4FCFF377}
.imagebase 0x00400000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x02CF0000


// =============== CLASS MEMBERS DECLARATION ===================

.class private auto ansi beforefieldinit Password.Program
       extends [mscorlib]System.Object
{
  .method private hidebysig static void  Main(string[] args) cil managed
  {
    .entrypoint
    // Code size       55 (0x37)
    .maxstack  2
    .locals init (string V_0,
             bool V_1)
    IL_0000:  nop
    //IL_0001:  ldstr      "Enter Password"
    //IL_0006:  call       void [mscorlib]System.Console::WriteLine(string)
    //IL_000b:  nop
    //IL_000c:  call       string [mscorlib]System.Console::ReadLine()
    //IL_0011:  stloc.0
    //IL_0012:  ldloc.0
    //IL_0013:  ldstr      "123abc"
    //IL_0018:  call       bool [mscorlib]System.String::op_Equality(string,
    //                                                               string)
    //IL_001d:  stloc.1
    //IL_001e:  ldloc.1
    //IL_001f:  brfalse.s  IL_0021//IL_002e
	
    IL_0021:  ldstr      "Congratulation!"
    IL_0026:  call       void [mscorlib]System.Console::WriteLine(string)
    IL_002b:  nop
    IL_002c:  br.s       IL_0030

    IL_002e:  br.s       IL_0036

    IL_0030:  call       valuetype [mscorlib]System.ConsoleKeyInfo [mscorlib]System.Console::ReadKey()
    IL_0035:  pop
    IL_0036:  ret
  } // end of method Program::Main

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  nop
    IL_0007:  ret
  } // end of method Program::.ctor

} // end of class Password.Program


// =============================================================

// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file E:\7sem\тарнавский\1лаб\Program.res
