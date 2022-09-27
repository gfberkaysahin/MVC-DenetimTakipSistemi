/// <reference path="datescript.js" />
function BelgeTipiData() {
    var url = '/Home/BelgeTipiTanim';
    $('#BelgeTipiTable').html("");
    var thead = "<thead>< tr ><th>Düzenle</th><th>Belge Tipi</th><th>Durum</th><th>Açıklama</th><th>Eklenme</th><th>Güncellenme</th></tr></thead >";
    $('#BelgeTipiTable').append(thead);
    $.getJSON(url, function (BelgeTipiGelenData) {
        for (var item in BelgeTipiGelenData.BResult) {
            var duzenle = '<button data-id="' + BelgeTipiGelenData.BResult[item].belge_tipi_id + '" class="belge_tipi_tanım_düzenle_open" data-dismiss="modal" style="background-color:deepskyblue;width:auto;height:30px;border-radius:5px;color:white;padding:2px;border-color:deepskyblue">Düzenle</button>'
            var eklnm_trh = dateConvert(BelgeTipiGelenData.BResult[item].belge_tipi_eklnm_trh);
            var eklenmetablo = "" + BelgeTipiGelenData.BResult[item].belge_tipi_eklyn_kllnc + " | " + eklnm_trh + "";
            var gncllnm_trh = dateConvert(BelgeTipiGelenData.BResult[item].belge_tipi_gncllnm_trh);
            var güncellemetablo = "" + BelgeTipiGelenData.BResult[item].belge_tipi_gncllyn_kllnc + " | " + gncllnm_trh + "";
            var values = ' <tbody><tr><td>' + duzenle + '</td><td>' + BelgeTipiGelenData.BResult[item].belge_tipi_tipi + '</td><td>' + BelgeTipiGelenData.BResult[item].belge_tipi_durum + '</td><td>' + BelgeTipiGelenData.BResult[item].belge_tipi_acklm + '</td><td>' + eklenmetablo + '</td><td>' + güncellemetablo + '</td></tr></tbody >'
            $('#BelgeTipiTable').append(values);
        }
    });
}