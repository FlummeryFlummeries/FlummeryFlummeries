$(document).ready(function () {
    $(".cart-icon").click(function () {
        $(".cart-mini").toggleClass('hide');
    });
    $(".address-toggle").change(function () {
        if ($(".address-info").hasClass("hide")) {
            $(".address-info").find("input").attr("required", true);
            $(".address-info").find("select").attr("required", true);
        } else {
            $(".address-info").find("input").attr("required", false);
            $(".address-info").find("select").attr("required", false);
        }
        $(".address-optional").attr("required", false)
        $(".address-info").toggleClass("hide");
    });
    $(".toggle-order").click(function (e) {
        $("#order-body-" + e.target.id).toggleClass('hide');
        e.stopPropagation();
    });
    $(':checkbox:checked').prop('checked', false);
});