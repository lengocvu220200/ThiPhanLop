// Scripts
// 

window.addEventListener('DOMContentLoaded', event => {

    // Activate Bootstrap scrollspy on the main nav element
    const mainNav = document.body.querySelector('#mainNav');
    if (mainNav) {
        new bootstrap.ScrollSpy(document.body, {
            target: '#mainNav',
            offset: 74,
        });
    };

    // Collapse responsive navbar when toggler is visible
    const navbarToggler = document.body.querySelector('.navbar-toggler');
    const responsiveNavItems = [].slice.call(
        document.querySelectorAll('#navbarResponsive .nav-link')
    );
    responsiveNavItems.map(function (responsiveNavItem) {
        responsiveNavItem.addEventListener('click', () => {
            if (window.getComputedStyle(navbarToggler).display !== 'none') {
                navbarToggler.click();
            }
        });
    });

});

//preloader
setTimeout(function () {
    $('.loader_bg').fadeToggle();
}, 1500);


//Custom

function ResetForm(id) {
    document.getElementById('Title').value = "";
    document.getElementById('NamSinh').value = "";
    document.getElementById('QRCode').value = "";
};

function Message() {
    var HoTen = document.forms["form1"]["HoTen"].value;
    var QRCode = document.forms["form1"]["QRCode"].value;
    if (HoTen == "" && QRCode == "" ) {
        alert("Vui lòng nhập tối thiểu họ tên hoặc mã QR code!");
        return false;
    }
    else {
        return true;
    }
};
