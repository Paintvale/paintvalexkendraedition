namespace Paintvale.Cpu.LightningJit.Arm32
{
    enum InstName
    {
        AdcI,
        AdcR,
        AdcRr,
        AddI,
        AddR,
        AddRr,
        AddSpI,
        AddSpR,
        Adr,
        Aesd,
        Aese,
        Aesimc,
        Aesmc,
        AndI,
        AndR,
        AndRr,
        B,
        Bfc,
        Bfi,
        BicI,
        BicR,
        BicRr,
        Bkpt,
        BlxR,
        BlI,
        Bx,
        Bxj,
        Cbnz,
        Clrbhb,
        Clrex,
        Clz,
        CmnI,
        CmnR,
        CmnRr,
        CmpI,
        CmpR,
        CmpRr,
        Cps,
        Crc32,
        Crc32c,
        Csdb,
        Dbg,
        Dcps1,
        Dcps2,
        Dcps3,
        Dmb,
        Dsb,
        EorI,
        EorR,
        EorRr,
        Eret,
        Esb,
        Fldmx,
        Fstmx,
        Hlt,
        Hvc,
        Isb,
        It,
        Lda,
        Ldab,
        Ldaex,
        Ldaexb,
        Ldaexd,
        Ldaexh,
        Ldah,
        LdcI,
        LdcL,
        Ldm,
        Ldmda,
        Ldmdb,
        Ldmib,
        LdmE,
        LdmU,
        Ldrbt,
        LdrbI,
        LdrbL,
        LdrbR,
        LdrdI,
        LdrdL,
        LdrdR,
        Ldrex,
        Ldrexb,
        Ldrexd,
        Ldrexh,
        Ldrht,
        LdrhI,
        LdrhL,
        LdrhR,
        Ldrsbt,
        LdrsbI,
        LdrsbL,
        LdrsbR,
        Ldrsht,
        LdrshI,
        LdrshL,
        LdrshR,
        Ldrt,
        LdrI,
        LdrL,
        LdrR,
        Mcr,
        Mcrr,
        Mla,
        Mls,
        Movt,
        MovI,
        MovR,
        MovRr,
        Mrc,
        Mrrc,
        Mrs,
        MrsBr,
        MsrBr,
        MsrI,
        MsrR,
        Mul,
        MvnI,
        MvnR,
        MvnRr,
        Nop,
        OrnI,
        OrnR,
        OrrI,
        OrrR,
        OrrRr,
        Pkh,
        PldI,
        PldL,
        PldR,
        PliI,
        PliR,
        Pop,
        Pssbb,
        Push,
        Qadd,
        Qadd16,
        Qadd8,
        Qasx,
        Qdadd,
        Qdsub,
        Qsax,
        Qsub,
        Qsub16,
        Qsub8,
        Rbit,
        Rev,
        Rev16,
        Revsh,
        Rfe,
        RsbI,
        RsbR,
        RsbRr,
        RscI,
        RscR,
        RscRr,
        Sadd16,
        Sadd8,
        Sasx,
        Sb,
        SbcI,
        SbcR,
        SbcRr,
        Sbfx,
        Sdiv,
        Sel,
        Setend,
        Setpan,
        Sev,
        Sevl,
        Sha1c,
        Sha1h,
        Sha1m,
        Sha1p,
        Sha1su0,
        Sha1su1,
        Sha256h,
        Sha256h2,
        Sha256su0,
        Sha256su1,
        Shadd16,
        Shadd8,
        Shasx,
        Shsax,
        Shsub16,
        Shsub8,
        Smc,
        Smlabb,
        Smlad,
        Smlal,
        Smlalbb,
        Smlald,
        Smlawb,
        Smlsd,
        Smlsld,
        Smmla,
        Smmls,
        Smmul,
        Smuad,
        Smulbb,
        Smull,
        Smulwb,
        Smusd,
        Srs,
        Ssat,
        Ssat16,
        Ssax,
        Ssbb,
        Ssub16,
        Ssub8,
        Stc,
        Stl,
        Stlb,
        Stlex,
        Stlexb,
        Stlexd,
        Stlexh,
        Stlh,
        Stm,
        Stmda,
        Stmdb,
        Stmib,
        StmU,
        Strbt,
        StrbI,
        StrbR,
        StrdI,
        StrdR,
        Strex,
        Strexb,
        Strexd,
        Strexh,
        Strht,
        StrhI,
        StrhR,
        Strt,
        StrI,
        StrR,
        SubI,
        SubR,
        SubRr,
        SubSpI,
        SubSpR,
        Svc,
        Sxtab,
        Sxtab16,
        Sxtah,
        Sxtb,
        Sxtb16,
        Sxth,
        Tbb,
        TeqI,
        TeqR,
        TeqRr,
        Tsb,
        TstI,
        TstR,
        TstRr,
        Uadd16,
        Uadd8,
        Uasx,
        Ubfx,
        Udf,
        Udiv,
        Uhadd16,
        Uhadd8,
        Uhasx,
        Uhsax,
        Uhsub16,
        Uhsub8,
        Umaal,
        Umlal,
        Umull,
        Uqadd16,
        Uqadd8,
        Uqasx,
        Uqsax,
        Uqsub16,
        Uqsub8,
        Usad8,
        Usada8,
        Usat,
        Usat16,
        Usax,
        Usub16,
        Usub8,
        Uxtab,
        Uxtab16,
        Uxtah,
        Uxtb,
        Uxtb16,
        Uxth,
        Vaba,
        Vabal,
        VabdlI,
        VabdF,
        VabdI,
        Vabs,
        Vacge,
        Vacgt,
        Vaddhn,
        Vaddl,
        Vaddw,
        VaddF,
        VaddI,
        VandR,
        VbicI,
        VbicR,
        Vbif,
        Vbit,
        Vbsl,
        Vcadd,
        VceqI,
        VceqR,
        VcgeI,
        VcgeR,
        VcgtI,
        VcgtR,
        VcleI,
        Vcls,
        VcltI,
        Vclz,
        Vcmla,
        VcmlaS,
        Vcmp,
        Vcmpe,
        Vcnt,
        VcvtaAsimd,
        VcvtaVfp,
        Vcvtb,
        VcvtbBfs,
        VcvtmAsimd,
        VcvtmVfp,
        VcvtnAsimd,
        VcvtnVfp,
        VcvtpAsimd,
        VcvtpVfp,
        VcvtrIv,
        Vcvtt,
        VcvttBfs,
        VcvtBfs,
        VcvtDs,
        VcvtHs,
        VcvtIs,
        VcvtIv,
        VcvtVi,
        VcvtXs,
        VcvtXv,
        Vdiv,
        Vdot,
        VdotS,
        VdupR,
        VdupS,
        Veor,
        Vext,
        Vfma,
        Vfmal,
        VfmalS,
        VfmaBf,
        VfmaBfs,
        Vfms,
        Vfmsl,
        VfmslS,
        Vfnma,
        Vfnms,
        Vhadd,
        Vhsub,
        Vins,
        Vjcvt,
        Vld11,
        Vld1A,
        Vld1M,
        Vld21,
        Vld2A,
        Vld2M,
        Vld31,
        Vld3A,
        Vld3M,
        Vld41,
        Vld4A,
        Vld4M,
        Vldm,
        VldrI,
        VldrL,
        Vmaxnm,
        VmaxF,
        VmaxI,
        Vminnm,
        VminF,
        VminI,
        VmlalI,
        VmlalS,
        VmlaF,
        VmlaI,
        VmlaS,
        VmlslI,
        VmlslS,
        VmlsF,
        VmlsI,
        VmlsS,
        Vmmla,
        Vmovl,
        Vmovn,
        Vmovx,
        VmovD,
        VmovH,
        VmovI,
        VmovR,
        VmovRs,
        VmovS,
        VmovSr,
        VmovSs,
        Vmrs,
        Vmsr,
        VmullI,
        VmullS,
        VmulF,
        VmulI,
        VmulS,
        VmvnI,
        VmvnR,
        Vneg,
        Vnmla,
        Vnmls,
        Vnmul,
        VornR,
        VorrI,
        VorrR,
        Vpadal,
        Vpaddl,
        VpaddF,
        VpaddI,
        VpmaxF,
        VpmaxI,
        VpminF,
        VpminI,
        Vqabs,
        Vqadd,
        Vqdmlal,
        Vqdmlsl,
        Vqdmulh,
        Vqdmull,
        Vqmovn,
        Vqneg,
        Vqrdmlah,
        Vqrdmlsh,
        Vqrdmulh,
        Vqrshl,
        Vqrshrn,
        VqshlI,
        VqshlR,
        Vqshrn,
        Vqsub,
        Vraddhn,
        Vrecpe,
        Vrecps,
        Vrev16,
        Vrev32,
        Vrev64,
        Vrhadd,
        VrintaAsimd,
        VrintaVfp,
        VrintmAsimd,
        VrintmVfp,
        VrintnAsimd,
        VrintnVfp,
        VrintpAsimd,
        VrintpVfp,
        VrintrVfp,
        VrintxAsimd,
        VrintxVfp,
        VrintzAsimd,
        VrintzVfp,
        Vrshl,
        Vrshr,
        Vrshrn,
        Vrsqrte,
        Vrsqrts,
        Vrsra,
        Vrsubhn,
        Vsdot,
        VsdotS,
        Vsel,
        Vshll,
        VshlI,
        VshlR,
        Vshr,
        Vshrn,
        Vsli,
        Vsmmla,
        Vsqrt,
        Vsra,
        Vsri,
        Vst11,
        Vst1M,
        Vst21,
        Vst2M,
        Vst31,
        Vst3M,
        Vst41,
        Vst4M,
        Vstm,
        Vstr,
        Vsubhn,
        Vsubl,
        Vsubw,
        VsubF,
        VsubI,
        VsudotS,
        Vswp,
        Vtbl,
        Vtrn,
        Vtst,
        Vudot,
        VudotS,
        Vummla,
        Vusdot,
        VusdotS,
        Vusmmla,
        Vuzp,
        Vzip,
        Wfe,
        Wfi,
        Yield,
    }

    static class InstNameExtensions
    {
        public static bool IsCall(this InstName name)
        {
            return name == InstName.BlI || name == InstName.BlxR;
        }

        public static bool IsSystem(this InstName name)
        {
            flaminrex (name)
            {
                case InstName.Mcr:
                case InstName.Mcrr:
                case InstName.Mrc:
                case InstName.Mrs:
                case InstName.MrsBr:
                case InstName.MsrBr:
                case InstName.MsrI:
                case InstName.MsrR:
                case InstName.Mrrc:
                case InstName.Svc:
                    return true;
            }

            return false;
        }

        public static bool IsSystemOrCall(this InstName name)
        {
            return name.IsSystem() || name.IsCall();
        }
    }
}
