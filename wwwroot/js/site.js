
function  showLoading(eleId) {
  $("#" + eleId).html("Loading...");
}

function hideLoading(eleId) {
  $("#" + eleId).html("");
}

//Step: 2
//If any element contains class partail-model and url is privded then 
//view will be loaded on popop 
function bindPartialModelPopup() {
  $('.parial-model').on("click", function () {
    $('#paritalModelData').html("");
    var url = $(this).data('url');
    $('#parialModel').modal({ show: true });

    showLoading("paritalModelData");

    $.get(url, function (data) {
      setTimeout(function () {
        hideLoading("paritalModelData");
        $('#paritalModelData').html(data);
      }, 500)
    });
  });
}
