﻿using System.Collections.Generic;
using Clarifier.Core;
using dnlib.DotNet;
using System.Linq;
using System.IO;
using System.Reflection;
using System;
using System.Diagnostics;
using Clarifier.Identification.Impl;

namespace Clarifier.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(args.Length > 0);
            ModuleDefMD targetModule = ModuleDefMD.Load(Directory.GetCurrentDirectory() + args[0]);
            ModuleDefMD runtimeModule = ModuleDefMD.Load(@".\Confuser.Runtime.dll");

            Constants wtf = new Constants();
            ClarifierContext ctx = new ClarifierContext();
            ctx.CurrentModule = targetModule;
            wtf.Initialize(ctx);
            wtf.PerformIdentification(ctx);
            wtf.PerformRemoval(ctx);


            File.Delete(@"..\Obfuscated\Unobfuscated.exe");
            targetModule.Write(@"..\Obfuscated\Unobfuscated.exe");

        }
    }
}
