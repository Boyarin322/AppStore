// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function cookiePolicyPopup() {
    var cookieNotification = document.querySelector('.cookie-notification');
    if (!localStorage.getItem('cookieNotification')) {
        Swal.fire({
            title: 'We use cookies to improve your experience on our site',
            icon: 'info',
            showCancelButton: true,
            confirmButtonText: 'Accept Cookies',
            cancelButtonText: 'Decline',
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33'
        }).then((result) => {
            if (result.isConfirmed) {
                localStorage.setItem('cookieNotification', true);
            } else {
                window.location.href = 'https://www.google.com'; // redirect to another page or do whatever you want
            }
        });
    }
}
cookiePolicyPopup();
