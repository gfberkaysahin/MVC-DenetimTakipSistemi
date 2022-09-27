/// <reference path="datescript.js" />
function KullaniciData() {
    var url = '/Home/KullaniciTanim';
    $('#Kullanicitable').html("");
    var thead = "<thead><tr><th>Düzenle</th><th>Kullanıcı Adı</th><th>Adı Soyadı</th><th>E-Mail</th><th>T.C. Kimlik No</th><th>Eklenme</th><th>Güncellenme</th></tr></thead>";
    $('#Kullanicitable').append(thead);
    $.getJSON(url, function (KullaniciGelenData) {
        for (var item in KullaniciGelenData.Result) {
            var duzenle = '<button data-id="' + KullaniciGelenData.Result[item].kllnc_id + '" class="kullanıcı_tanım_düzenle_open" data-dismiss="modal" style="background-color:deepskyblue;width:auto;height:30px;border-radius:5px;color:white;padding:2px;border-color:deepskyblue">Düzenle</button>'
            var eklnm_trh = dateConvert(KullaniciGelenData.Result[item].kllnc_eklnm_trh);
            var eklenmetablo = "" + KullaniciGelenData.Result[item].kllnc_eklyn_kllnc + " | " + eklnm_trh +"";
            var gncllnm_trh = dateConvert(KullaniciGelenData.Result[item].kllnc_gncllnm_trh);
            var güncellemetablo = ""+ KullaniciGelenData.Result[item].kllnc_gnclln_kllnc + " | " + gncllnm_trh + "";
            var values = ' <tbody><tr><td>' + duzenle + '</td><td>' + KullaniciGelenData.Result[item].kllnc_kllncad + '</td><td>' + KullaniciGelenData.Result[item].kllnc_adi + '</td><td>' + KullaniciGelenData.Result[item].kllnc_epsta + '</td><td>' + KullaniciGelenData.Result[item].kllnc_kmlk_no + '</td><td>' + eklenmetablo + '</td><td>' + güncellemetablo + '</td></tr></tbody >'
            $('#Kullanicitable').append(values);
        }
    });
}
