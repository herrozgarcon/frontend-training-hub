/**
 * Zoomcars - Authentication Controller (Log In & Sign Up)
 * Controls tab switching, password toggles, Google One-Tap authentication,
 * and form submissions with seamless feedback and navigation.
 */

document.addEventListener('DOMContentLoaded', () => {
    // Elements
    const tabBtns = document.querySelectorAll('.auth-tab-btn');
    const loginForm = document.getElementById('loginForm');
    const signupForm = document.getElementById('signupForm');
    const authHeading = document.getElementById('authHeading');
    const authSubheading = document.getElementById('authSubheading');
    const toggleToSignup = document.getElementById('toggleToSignup');
    const toggleToLogin = document.getElementById('toggleToLogin');
    
    // Google Modal Elements
    const btnGoogleAuth = document.getElementById('btnGoogleAuth');
    const googleModalOverlay = document.getElementById('googleModalOverlay');
    const googleModalClose = document.getElementById('googleModalClose');
    const googleAccountRows = document.querySelectorAll('.google-account-row');

    // Toast Alert
    const authToast = document.getElementById('authToast');
    const toastMessage = document.getElementById('toastMessage');

    function showToast(message, icon = '✅') {
        if (!authToast || !toastMessage) return;
        toastMessage.textContent = message;
        const iconEl = authToast.querySelector('.toast-icon');
        if (iconEl) iconEl.textContent = icon;

        authToast.classList.add('show');
        setTimeout(() => {
            authToast.classList.remove('show');
        }, 3200);
    }

    // Switch between Login and Sign Up
    function switchMode(mode) {
        if (mode === 'signup') {
            tabBtns.forEach(btn => btn.classList.toggle('active', btn.dataset.tab === 'signup'));
            if (loginForm) loginForm.style.display = 'none';
            if (signupForm) signupForm.style.display = 'block';
            if (authHeading) authHeading.textContent = 'Create an Account';
            if (authSubheading) authSubheading.textContent = 'Join 500,000+ drivers and unlock instant booking.';
        } else {
            tabBtns.forEach(btn => btn.classList.toggle('active', btn.dataset.tab === 'login'));
            if (loginForm) loginForm.style.display = 'block';
            if (signupForm) signupForm.style.display = 'none';
            if (authHeading) authHeading.textContent = 'Welcome Back';
            if (authSubheading) authSubheading.textContent = 'Sign in to access your fleet reservations and trips.';
        }
    }

    // Tab button click listeners
    tabBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            switchMode(btn.dataset.tab);
        });
    });

    if (toggleToSignup) {
        toggleToSignup.addEventListener('click', (e) => {
            e.preventDefault();
            switchMode('signup');
        });
    }

    if (toggleToLogin) {
        toggleToLogin.addEventListener('click', (e) => {
            e.preventDefault();
            switchMode('login');
        });
    }

    // Password Show / Hide Toggles
    const togglePasswordBtns = document.querySelectorAll('.auth-password-toggle');
    togglePasswordBtns.forEach(btn => {
        btn.addEventListener('click', () => {
            const targetId = btn.dataset.target;
            const input = document.getElementById(targetId);
            if (!input) return;

            if (input.type === 'password') {
                input.type = 'text';
                btn.textContent = '🙈';
                btn.setAttribute('aria-label', 'Hide password');
            } else {
                input.type = 'password';
                btn.textContent = '👁️';
                btn.setAttribute('aria-label', 'Show password');
            }
        });
    });

    // Google Authentication Flow Simulation
    if (btnGoogleAuth && googleModalOverlay) {
        btnGoogleAuth.addEventListener('click', () => {
            googleModalOverlay.style.display = 'flex';
        });
    }

    if (googleModalClose && googleModalOverlay) {
        googleModalClose.addEventListener('click', () => {
            googleModalOverlay.style.display = 'none';
        });

        googleModalOverlay.addEventListener('click', (e) => {
            if (e.target === googleModalOverlay) {
                googleModalOverlay.style.display = 'none';
            }
        });
    }

    // Handle Google Account selection
    googleAccountRows.forEach(row => {
        row.addEventListener('click', () => {
            const userName = row.dataset.name || 'User';
            if (googleModalOverlay) googleModalOverlay.style.display = 'none';

            showToast(`Connected with Google as ${userName}! Redirecting...`, '⚡');

            setTimeout(() => {
                window.location.href = 'index.html';
            }, 1400);
        });
    });

    // Handle Log In Form Submission
    if (loginForm) {
        loginForm.addEventListener('submit', (e) => {
            e.preventDefault();
            const submitBtn = loginForm.querySelector('.btn-auth-submit');
            const originalText = submitBtn ? submitBtn.innerHTML : 'Log In';

            if (submitBtn) {
                submitBtn.disabled = true;
                submitBtn.innerHTML = `
                    <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                    Authenticating...
                `;
            }

            setTimeout(() => {
                showToast('Welcome back! Login successful. Redirecting...', '🚗');
                setTimeout(() => {
                    window.location.href = 'index.html';
                }, 1200);
            }, 800);
        });
    }

    // Handle Sign Up Form Submission
    if (signupForm) {
        signupForm.addEventListener('submit', (e) => {
            e.preventDefault();
            const submitBtn = signupForm.querySelector('.btn-auth-submit');
            const originalText = submitBtn ? submitBtn.innerHTML : 'Create Account';

            if (submitBtn) {
                submitBtn.disabled = true;
                submitBtn.innerHTML = `
                    <span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span>
                    Setting Up Account...
                `;
            }

            setTimeout(() => {
                showToast('Account created successfully! Welcome to Zoomcars.', '🎉');
                setTimeout(() => {
                    window.location.href = 'index.html';
                }, 1200);
            }, 900);
        });
    }

    // Handle URL parameters (e.g. ?mode=signup)
    const urlParams = new URLSearchParams(window.location.search);
    if (urlParams.get('mode') === 'signup') {
        switchMode('signup');
    }
});
