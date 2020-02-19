
var genelToplam;
var kebatic, kebatdis, kagitgramic, kagitgramdis, icsonuc, dissonuc, KadetIc, KadetDis, TabakaIc, FersudeIc, TabakaDis, FersudeDıs, KagitTon, Vade, KKagitTon, KDoviz, KVade;
function CallChangefunc() {
    
    //diğer
    var qwe = document.getElementById("TBMakinaDis").value.replace(/,/g, ".").replace("","0");
    var asd = document.getElementById("TBebatDis").value.replace(/,/g, ".").replace("", "0");
    var zxc = document.getElementById("TBadetDis").value.replace(/,/g, ".").replace("", "0");
    var rty = document.getElementById("TBbaskiDis").value.replace(/,/g, ".").replace("", "0");
    var fgh = document.getElementById("TBrenkDis").value.replace(/,/g, ".").replace("", "0");
    var vbn = document.getElementById("TBkalipDis").value.replace(/,/g, ".").replace("", "0");
    var wer = document.getElementById("TBformaDis").value.replace(/,/g, ".").replace("", "0");
    var sdf = document.getElementById("TSselefonDis").value.replace(/,/g, ".").replace("", "0");
    var xcv = document.getElementById("TSlakDis").value.replace(/,/g, ".").replace("", "0");
    var ert = document.getElementById("TSgofreDis").value.replace(/,/g, ".").replace("", "0");
    var dfg = document.getElementById("TSvarakDis").value.replace(/,/g, ".").replace("", "0");
    var cvb = document.getElementById("TSperforajDis").value.replace(/,/g, ".").replace("", "0");
    var tyu = document.getElementById("TSozelKesimDİs").value.replace(/,/g, ".").replace("", "0");
    var ghj = document.getElementById("TSciltDis").value.replace(/,/g, ".").replace("", "0");
    var bnm = document.getElementById("TSkirimDis").value.replace(/,/g, ".").replace("", "0");
    var yuı = document.getElementById("TSyapistirmaDis").value.replace(/,/g, ".").replace("", "0");
    var hjk = document.getElementById("TSsivamaDis").value.replace(/,/g, ".").replace("", "0");
    var nml = document.getElementById("TStaslamaDis").value.replace(/,/g, ".").replace("", "0");
    var ewq = document.getElementById("TSnumaratorDis").value.replace(/,/g, ".").replace("", "0");
    var dsa = document.getElementById("TSkesimDis").value.replace(/,/g, ".").replace("", "0");
    var cxz = document.getElementById("TSpaketDis").value.replace(/,/g, ".").replace("", "0");
    //kapak
    var Kqwe = document.getElementById("2TBMakinaDis").value.replace(/,/g, ".").replace("", "0");
    var Kasd = document.getElementById("2TBebatDis").value.replace(/,/g, ".").replace("", "0");
    var Kzxc = document.getElementById("2TBadetDis").value.replace(/,/g, ".").replace("", "0");
    var Krty = document.getElementById("2TBbaskiDis").value.replace(/,/g, ".").replace("", "0");
    var Kfgh = document.getElementById("2TBrenkDis").value.replace(/,/g, ".").replace("", "0");
    var Kvbn = document.getElementById("2TBkalipDis").value.replace(/,/g, ".").replace("", "0");
    var Kwer = document.getElementById("2TBformaDis").value.replace(/,/g, ".").replace("", "0");
    var Ksdf = document.getElementById("2TSselefonDis").value.replace(/,/g, ".").replace("", "0");
    var Kxcv = document.getElementById("2TSlakDis").value.replace(/,/g, ".").replace("", "0");
    var Kert = document.getElementById("2TSgofreDis").value.replace(/,/g, ".").replace("", "0");
    var Kdfg = document.getElementById("2TSvarakDis").value.replace(/,/g, ".").replace("", "0");
    var Kcvb = document.getElementById("2TSperforajDis").value.replace(/,/g, ".").replace("", "0");
    var Ktyu = document.getElementById("2TSozelKesimDİs").value.replace(/,/g, ".").replace("", "0");
    var Kghj = document.getElementById("2TSciltDis").value.replace(/,/g, ".").replace("", "0");
    var Kbnm = document.getElementById("2TSkirimDis").value.replace(/,/g, ".").replace("", "0");
    var Kyuı = document.getElementById("2TSyapistirmaDis").value.replace(/,/g, ".").replace("", "0");
    var Khjk = document.getElementById("2TSsivamaDis").value.replace(/,/g, ".").replace("", "0");
    var Knml = document.getElementById("2TStaslamaDis").value.replace(/,/g, ".").replace("", "0");
    var Kewq = document.getElementById("2TSnumaratorDis").value.replace(/,/g, ".").replace("", "0");
    var Kdsa = document.getElementById("2TSkesimDis").value.replace(/,/g, ".").replace("", "0");
    var Kcxz = document.getElementById("2TSpaketDis").value.replace(/,/g, ".").replace("", "0");
    //kağıt
    var a = $('#KagitGramiIc option:selected').text();
    var b = $('#KagitGramiDis option:selected').text();
    var c = $('#KebatIc option:selected').text();
    var d = $('#KebatDis option:selected').text();
    var f = document.getElementById("KadetIc").value;
    var g = document.getElementById("KadetDis").value;
    var h = document.getElementById("TabakaIc").value;
    var y = document.getElementById("TabakaDis").value;
    var l = document.getElementById("FersudeIc").value;
    var u = document.getElementById("FersudeDıs").value;
    var er = document.getElementById("KagitTon").value;
    var df = document.getElementById("Doviz").value;
    var cv = document.getElementById("Vade").value;
    var ty = document.getElementById("KKagitTon").value;
    var gh = document.getElementById("KDoviz").value;
    var bn = document.getElementById("KVade").value;
    //diğer
    BMakinaDis = parseFloat(qwe);
    BebatDis = parseFloat(asd);
    BadetDis = parseFloat(zxc);
    BbaskiDis = parseFloat(rty);
    BrenkDis = parseFloat(fgh);
    BkalipDis = parseFloat(vbn);
    BformaDis = parseFloat(wer); 
    SselefonDis = parseFloat(sdf);
    SlakDis = parseFloat(xcv);
    SgofreDis = parseFloat(ert);
    SvarakDis = parseFloat(dfg);
    SperforajDis = parseFloat(cvb);
    SozelKesimDİs = parseFloat(tyu);
    SciltDis = parseFloat(ghj);
    SkirimDis = parseFloat(bnm);
    SyapistirmaDis = parseFloat(yuı);
    SsivamaDis = parseFloat(hjk);
    StaslamaDis = parseFloat(nml);
    SnumaratorDis = parseFloat(ewq);
    SkesimDis = parseFloat(dsa);
    SpaketDis = parseFloat(cxz);
    //kapak
    KBMakinaDis = parseFloat(Kqwe);
    KBebatDis = parseFloat(Kasd);
    KBadetDis = parseFloat(Kzxc);
    KBbaskiDis = parseFloat(Krty);
    KBrenkDis = parseFloat(Kfgh);
    KBkalipDis = parseFloat(Kvbn);
    KBformaDis = parseFloat(Kwer);
    KSselefonDis = parseFloat(Ksdf);
    KSlakDis = parseFloat(Kxcv);
    KSgofreDis = parseFloat(Kert);
    KSvarakDis = parseFloat(Kdfg);
    KSperforajDis = parseFloat(Kcvb);
    KSozelKesimDİs = parseFloat(Ktyu);
    KSciltDis = parseFloat(Kghj);
    KSkirimDis = parseFloat(Kbnm);
    KSyapistirmaDis = parseFloat(Kyuı);
    KSsivamaDis = parseFloat(Khjk);
    KStaslamaDis = parseFloat(Knml);
    KSnumaratorDis = parseFloat(Kewq);
    KSkesimDis = parseFloat(Kdsa);
    KSpaketDis = parseFloat(Kcxz);
    var KToplam = KBMakinaDis + KBebatDis + KBadetDis + KBbaskiDis + KBrenkDis + KBkalipDis + KBformaDis + KSselefonDis + KSlakDis + KSgofreDis + KSvarakDis + KSperforajDis + KSozelKesimDİs + KSciltDis + KSkirimDis + KSyapistirmaDis + KSsivamaDis + KStaslamaDis + KSnumaratorDis + KSkesimDis + KSpaketDis;
    //
    var Doviz = df.replace(/,/g, ".");
    var KDoviz = gh.replace(/,/g, ".");
    TabakaIc = parseInt(h);
    TabakaDis = parseInt(y);
    FersudeIc = parseInt(l);
    FersudeDıs = parseInt(u);
    KadetIc = parseInt(f);
    KadetDis = parseInt(g);
    kagitgramic=parseInt(a);
    kagitgramdis = parseInt(b);
    KagitTon = parseFloat(er);
    DovizZ = parseFloat(Doviz);
    Vade = parseInt(cv);
    KKagitTon = parseFloat(ty);
    KDovizZ = parseFloat(KDoviz);
    KVade = parseInt(bn);
    //diğer





    switch (c) {
        case "50x70":
            kebatic = 50 * 70;
            break;
        case "57x82":
            kebatic = 57 * 82;
            break;
        case "64x90":
            kebatic = 64 * 90;
            break;
        case "70x100":
            kebatic = 70 * 100;
            break;
        default:
            kebatic = 1;
            break;

    }
    switch (d) {
        case "50x70":
            kebatdis = 50 * 70;
            break;
        case "57x82":
            kebatdis = 57 * 82;
            break;
        case "64x90":
            kebatdis = 64 * 90;
            break;
        case "70x100":
            kebatdis = 70 * 100;
            break;
        default:
            kebatdis = 1;
            break;

    }
    icsonuc = ((kebatic * kagitgramic) / 10000000).toFixed(3);
    dissonuc = ((kebatdis * kagitgramdis) / 10000000).toFixed(3);
    var Burak = (KadetIc / TabakaIc) + FersudeIc;
    var BurakKapak = (KadetDis / TabakaDis) + FersudeDıs;
    var KagitKg = (KagitTon * DovizZ) / 1000;
    document.getElementById("icesonuc").innerText = "Kağıt Gr. : " + icsonuc;
    document.getElementById("disesonuc").innerText =dissonuc;
    document.getElementById("icadetsonuc").innerText = "Tabaka Adeti: " + Burak;
    document.getElementById("disadetsonuc").innerText =BurakKapak;
    var KagıtTon = Burak * icsonuc;
    var KagitTonKapak = BurakKapak * dissonuc;
    document.getElementById("FersudeGree").innerText = "Kağıt Tonajı(kg) : " + KagıtTon.toFixed(2);
    document.getElementById("KapakFersudeGree").innerText = KagitTonKapak.toFixed(2);
    document.getElementById("KagitKgSon").innerText = KagitKg.toFixed(0);
    var KagitVade = KagitKg * Vade / 100 + KagitKg;
    document.getElementById("KagitVade").innerText = KagitVade.toFixed(0);
    var Sonuc = KagitVade * KagıtTon;
    document.getElementById("KagitTutar").innerText = Sonuc.toFixed(0)+"₺";
    /////kapak
    var KKagitKg = (KKagitTon * KDovizZ) / 1000;
    document.getElementById("KKagitKgSon").innerText = KKagitKg.toFixed(0);
    var KKagitVade = KKagitKg * KVade / 100 + KKagitKg;
    document.getElementById("KKagitVade").innerText = KKagitVade.toFixed(0);
    var KSonuc = KKagitVade * KagitTonKapak;
    document.getElementById("KKagitTutar").innerText = KSonuc.toFixed(0)+"₺";



    var BuyukSonuc = BMakinaDis + BebatDis + BadetDis + BbaskiDis + BrenkDis + BkalipDis + BformaDis + SselefonDis + SlakDis + SgofreDis + SvarakDis + SperforajDis + SozelKesimDİs + SciltDis + SkirimDis + SyapistirmaDis + SsivamaDis + StaslamaDis + SnumaratorDis + SkesimDis + SpaketDis + Sonuc;
    document.getElementById("SonucBuyuk").innerText = BuyukSonuc.toFixed(2)+"₺";
    var TBuyukSonuc = KToplam + KSonuc;
    document.getElementById("2SonucBuyuk").innerText = TBuyukSonuc.toFixed(2) + "₺";
    
    var toplam = BuyukSonuc + TBuyukSonuc;
    var GenelToplam = toplam;
   
    document.getElementById("ToplamTutar").value = GenelToplam.toFixed(2)
 
    
       
   
}
