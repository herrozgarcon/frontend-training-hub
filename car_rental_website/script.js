/**
 * Zoomcars - Automatic Endless Reel Slideshow Controller
 * Controls smooth infinite carousel cycling and animated reel progress indicators.
 */
document.addEventListener('DOMContentLoaded', () => {
    const carouselEl = document.getElementById('carouselExampleDark');
    if (!carouselEl) return;

    const DURATION = 3500; // Time in ms for each reel slide
    let carouselInstance = null;
    let progressStartTime = 0;
    let elapsedBeforePause = 0;
    let isPaused = false;
    let animFrameId = null;

    const slideItems = carouselEl.querySelectorAll('.carousel-item');
    const indicatorButtons = carouselEl.querySelectorAll('.carousel-indicators button');

    // Determine initial active index
    let activeIndex = 0;
    slideItems.forEach((item, idx) => {
        if (item.classList.contains('active')) {
            activeIndex = idx;
        }
    });

    // Initialize Bootstrap Carousel if available
    if (window.bootstrap && window.bootstrap.Carousel) {
        carouselInstance = window.bootstrap.Carousel.getOrCreateInstance(carouselEl, {
            interval: false, // Progress loop manages timing to ensure 100% sync
            wrap: true,
            touch: true
        });
    }

    function updateIndicators(currIdx, percent) {
        indicatorButtons.forEach((btn, idx) => {
            const progressBar = btn.querySelector('.indicator-progress');
            if (idx === currIdx) {
                btn.classList.add('active');
                btn.setAttribute('aria-current', 'true');
                if (progressBar) {
                    progressBar.style.width = `${Math.min(100, Math.max(0, percent))}%`;
                }
            } else if (idx < currIdx) {
                btn.classList.remove('active');
                btn.removeAttribute('aria-current');
                if (progressBar) {
                    progressBar.style.width = '100%';
                }
            } else {
                btn.classList.remove('active');
                btn.removeAttribute('aria-current');
                if (progressBar) {
                    progressBar.style.width = '0%';
                }
            }
        });
    }

    function advanceSlide(direction = 'next') {
        if (carouselInstance) {
            if (direction === 'prev') {
                carouselInstance.prev();
            } else {
                carouselInstance.next();
            }
        } else {
            // Pure JS fallback if Bootstrap library is not yet loaded or blocked
            const total = slideItems.length;
            if (total === 0) return;
            const targetIdx = direction === 'prev'
                ? (activeIndex - 1 + total) % total
                : (activeIndex + 1) % total;
            goToSlide(targetIdx);
        }
    }

    function goToSlide(targetIdx) {
        if (slideItems.length === 0) return;
        slideItems[activeIndex].classList.remove('active');
        slideItems[targetIdx].classList.add('active');
        startProgressForSlide(targetIdx);
    }

    function animateProgress(timestamp) {
        if (!progressStartTime) progressStartTime = timestamp;

        if (!isPaused) {
            const currentElapsed = elapsedBeforePause + (timestamp - progressStartTime);
            const percent = (currentElapsed / DURATION) * 100;
            updateIndicators(activeIndex, percent);

            if (currentElapsed >= DURATION) {
                advanceSlide('next');
                return;
            }
        }

        animFrameId = requestAnimationFrame(animateProgress);
    }

    function startProgressForSlide(index) {
        if (animFrameId) {
            cancelAnimationFrame(animFrameId);
            animFrameId = null;
        }
        activeIndex = index;
        progressStartTime = 0;
        elapsedBeforePause = 0;
        updateIndicators(activeIndex, 0);

        if (!isPaused) {
            animFrameId = requestAnimationFrame(animateProgress);
        }
    }

    // Sync when slide transition starts (Bootstrap event)
    carouselEl.addEventListener('slide.bs.carousel', (event) => {
        startProgressForSlide(event.to);
    });

    // Fallback click handlers for manual indicator navigation
    indicatorButtons.forEach((btn, idx) => {
        btn.addEventListener('click', () => {
            if (!carouselInstance) {
                goToSlide(idx);
            }
        });
    });

    // Fallback click handlers for arrow buttons
    const prevControl = carouselEl.querySelector('.carousel-control-prev');
    const nextControl = carouselEl.querySelector('.carousel-control-next');
    if (prevControl) {
        prevControl.addEventListener('click', (e) => {
            if (!carouselInstance) {
                e.preventDefault();
                advanceSlide('prev');
            }
        });
    }
    if (nextControl) {
        nextControl.addEventListener('click', (e) => {
            if (!carouselInstance) {
                e.preventDefault();
                advanceSlide('next');
            }
        });
    }

    // Pause reel when hovering over the carousel
    carouselEl.addEventListener('mouseenter', () => {
        if (!isPaused) {
            isPaused = true;
            if (progressStartTime > 0) {
                elapsedBeforePause += (performance.now() - progressStartTime);
            }
        }
    });

    // Resume when cursor leaves the carousel
    carouselEl.addEventListener('mouseleave', () => {
        if (isPaused) {
            isPaused = false;
            progressStartTime = performance.now();
            if (!animFrameId) {
                animFrameId = requestAnimationFrame(animateProgress);
            }
        }
    });

    // Pause when page tab is hidden, resume when focused
    document.addEventListener('visibilitychange', () => {
        if (document.hidden) {
            if (!isPaused && progressStartTime > 0) {
                elapsedBeforePause += (performance.now() - progressStartTime);
            }
            isPaused = true;
        } else {
            isPaused = false;
            progressStartTime = performance.now();
            if (!animFrameId) {
                animFrameId = requestAnimationFrame(animateProgress);
            }
        }
    });

    // Initial reel countdown launch
    startProgressForSlide(activeIndex);
});

/**
 * ========================================================
 * Quick Car Rental Booking Nav-Dock & Modal Suggestion Engine
 * Provides a centered popup window with background blur,
 * rich detailed location cards, and smooth date synchronization.
 * ========================================================
 */
document.addEventListener('DOMContentLoaded', () => {
    // Stored Locations Database with Rich Details
    const STORED_LOCATIONS = [
        {
            id: 'lax',
            name: "Los Angeles Int'l Airport (LAX)",
            code: 'LAX',
            subtitle: '1 World Way, Los Angeles, CA • Terminals 1–7 & Tom Bradley',
            category: 'airport',
            icon: '✈️',
            rating: '★ 4.95 (540+ trips)',
            cars: '38 cars ready',
            perks: ['⚡ Curbside Valet', '🔑 24/7 Keyless Unlock', '🛡️ Zero Deposit'],
            isInstant: true
        },
        {
            id: 'sfo',
            name: "San Francisco Int'l Airport (SFO)",
            code: 'SFO',
            subtitle: 'Highway 101, San Francisco, CA • Domestic & Int\'l Terminals',
            category: 'airport',
            icon: '✈️',
            rating: '★ 4.92 (380+ trips)',
            cars: '26 cars ready',
            perks: ['⚡ AirTrain Direct', '🔑 Keyless Mobile App', '🛡️ Fully Insured'],
            isInstant: true
        },
        {
            id: 'jfk',
            name: "John F. Kennedy Int'l Airport (JFK)",
            code: 'JFK',
            subtitle: 'Queens, New York, NY • Terminals 1, 4, 5, 7 & 8',
            category: 'airport',
            icon: '✈️',
            rating: '★ 4.94 (610+ trips)',
            cars: '44 cars ready',
            perks: ['⚡ VIP Meet & Greet', '🔑 24/7 Counter', '🛡️ No Hidden Fees'],
            isInstant: true
        },
        {
            id: 'mia',
            name: 'Miami International Airport (MIA)',
            code: 'MIA',
            subtitle: '2100 NW 42nd Ave, Miami, FL • Rental Car Center Level 3',
            category: 'airport',
            icon: '✈️',
            rating: '★ 4.98 (490+ trips)',
            cars: '31 cars ready',
            perks: ['⚡ Convertible Fleet', '🔑 Instant Keyless', '🛡️ Free Cancellation'],
            isInstant: true
        },
        {
            id: 'ord',
            name: "Chicago O'Hare Int'l Airport (ORD)",
            code: 'ORD',
            subtitle: '10000 W O\'Hare Ave, Chicago, IL • Multi-Modal Facility',
            category: 'airport',
            icon: '✈️',
            rating: '★ 4.89 (310+ trips)',
            cars: '22 cars ready',
            perks: ['⚡ Heated Garage Pickup', '🔑 24/7 Unlock', '🛡️ 24/7 Roadside'],
            isInstant: false
        },
        {
            id: 'blr',
            name: "Kempegowda Int'l Airport (BLR)",
            code: 'BLR',
            subtitle: 'Devanahalli, Bengaluru, KA • Terminal 1 & T2 Arrival Curb',
            category: 'airport',
            icon: '✈️',
            rating: '★ 4.93 (420+ trips)',
            cars: '28 cars ready',
            perks: ['⚡ Chauffeur or Self-Drive', '🔑 Fast Track Exit', '🛡️ Zero Security Lock'],
            isInstant: true
        },
        {
            id: 'del',
            name: "Indira Gandhi Int'l Airport (DEL)",
            code: 'DEL',
            subtitle: 'New Delhi, Delhi NCR • Terminal 3 Multi-Level Parking',
            category: 'airport',
            icon: '✈️',
            rating: '★ 4.91 (560+ trips)',
            cars: '35 cars ready',
            perks: ['⚡ Premium Lounge Delivery', '🔑 24/7 Service', '🛡️ Verified Fleet'],
            isInstant: true
        },
        {
            id: 'bh',
            name: 'Beverly Hills & Rodeo Drive Hub',
            code: 'LA',
            subtitle: 'Wilshire Blvd & Rodeo Dr, Beverly Hills, CA',
            category: 'city',
            icon: '🏙️',
            rating: '★ 4.97 (280+ trips)',
            cars: '19 cars ready',
            perks: ['⚡ Exotic Supercars', '🔑 Hotel Valet Dropoff', '🛡️ Concierge Service'],
            isInstant: true
        },
        {
            id: 'nyc-dt',
            name: 'Manhattan Midtown & Times Square',
            code: 'NYC',
            subtitle: 'Broadway & 42nd St, New York, NY',
            category: 'city',
            icon: '🏙️',
            rating: '★ 4.90 (510+ trips)',
            cars: '29 cars ready',
            perks: ['⚡ 24/7 Garage Access', '🔑 Mobile Unlock', '🛡️ Unlimited Toll Pass'],
            isInstant: true
        },
        {
            id: 'sf-dt',
            name: 'Union Square & Financial District',
            code: 'SF',
            subtitle: 'Market St & Powell, San Francisco, CA',
            category: 'city',
            icon: '🏙️',
            rating: '★ 4.88 (240+ trips)',
            cars: '16 cars ready',
            perks: ['⚡ EV Fast Charging Hub', '🔑 Contactless Pick', '🛡️ Zero Deposit'],
            isInstant: true
        },
        {
            id: 'mia-sb',
            name: 'South Beach Ocean Drive VIP Point',
            code: 'MIA',
            subtitle: 'Collins Ave & 10th St, Miami Beach, FL',
            category: 'city',
            icon: '🏙️',
            rating: '★ 4.96 (390+ trips)',
            cars: '24 cars ready',
            perks: ['⚡ Beachfront Valet', '🔑 Luxury Convertibles', '🛡️ Clean Sanitized'],
            isInstant: true
        },
        {
            id: 'las-strip',
            name: 'Las Vegas Strip & Bellagio Center',
            code: 'LV',
            subtitle: 'Las Vegas Blvd, Las Vegas, NV',
            category: 'city',
            icon: '🏙️',
            rating: '★ 4.94 (440+ trips)',
            cars: '27 cars ready',
            perks: ['⚡ Casino Valet Delivery', '🔑 24/7 Instant Unlock', '🛡️ VIP Rates'],
            isInstant: true
        },
        {
            id: 'blr-idr',
            name: 'Indiranagar 100 Feet Road Lounge',
            code: 'BLR',
            subtitle: 'Indiranagar 12th Main, Bengaluru, KA',
            category: 'city',
            icon: '🏙️',
            rating: '★ 4.89 (190+ trips)',
            cars: '18 cars ready',
            perks: ['⚡ Metro Accessible Hub', '🔑 Instant Keyless', '🛡️ Fuel Inclusive Plans'],
            isInstant: false
        },
        {
            id: 'del-cp',
            name: 'Connaught Place Central Hub',
            code: 'DEL',
            subtitle: 'Inner Circle Block B, New Delhi, Delhi',
            category: 'city',
            icon: '🏙️',
            rating: '★ 4.92 (310+ trips)',
            cars: '21 cars ready',
            perks: ['⚡ Heritage Hub Delivery', '🔑 Mobile App Access', '🛡️ 24/7 Road Support'],
            isInstant: true
        }
    ];

    // DOM Elements - Booking Dock
    const pickupSegment = document.getElementById('pickupSegment');
    const pickupInput = document.getElementById('pickupInput');
    const dropoffSegment = document.getElementById('dropoffSegment');
    const dropoffInput = document.getElementById('dropoffInput');
    const toggleSameBtn = document.getElementById('toggleSameLocation');

    const pickupDateSegment = document.getElementById('pickupDateSegment');
    const pickupDateDisplay = document.getElementById('pickupDateDisplay');
    const pickupDatePopover = document.getElementById('pickupDatePopover');
    const btnClosePickupPopover = document.getElementById('btnClosePickupPopover');
    const btnApplyPickupPopover = document.getElementById('btnApplyPickupPopover');

    const returnDateSegment = document.getElementById('returnDateSegment');
    const returnDateDisplay = document.getElementById('returnDateDisplay');
    const returnDatePopover = document.getElementById('returnDatePopover');
    const btnCloseReturnPopover = document.getElementById('btnCloseReturnPopover');
    const btnApplyReturnPopover = document.getElementById('btnApplyReturnPopover');

    const vehicleSegment = document.getElementById('vehicleSegment');
    const vehicleCategoryDisplay = document.getElementById('vehicleCategoryDisplay');
    const vehicleCategoryPopover = document.getElementById('vehicleCategoryPopover');
    const btnCloseVehiclePopover = document.getElementById('btnCloseVehiclePopover');
    const vehicleOptionItems = document.querySelectorAll('.vehicle-option-item');

    const pickupDateInput = document.getElementById('pickupDate');
    const returnDateInput = document.getElementById('returnDate');
    const pickupTimeSelect = document.getElementById('pickupTime');
    const returnTimeSelect = document.getElementById('returnTime');
    const vehicleCategorySelect = document.getElementById('vehicleCategory');
    const searchBtn = document.getElementById('btnDockSearch');

    // DOM Elements - Centered Popup Modal
    const modalOverlay = document.getElementById('locationModalOverlay');
    const modalTitle = document.getElementById('modalLocationTitle');
    const btnCloseModal = document.getElementById('btnCloseLocationModal');
    const modalSearchInput = document.getElementById('modalLocationSearchInput');
    const btnClearSearch = document.getElementById('btnClearModalSearch');
    const modalSuggestionsContainer = document.getElementById('modalSuggestionsContainer');
    const modalFilterChips = document.querySelectorAll('.modal-filter-chip');
    const modalLocationCount = document.getElementById('modalLocationCount');

    // Feedback Toast Elements
    const feedbackToast = document.getElementById('bookingFeedbackToast');
    const toastTitle = document.getElementById('toastTitle');
    const toastDesc = document.getElementById('toastDesc');
    const btnCloseToast = document.getElementById('btnCloseToast');

    // Modal State
    let currentTarget = 'pickup'; // 'pickup' | 'dropoff'
    let currentCategoryFilter = 'all';

    // Date Initializations (Defaults: Tomorrow -> +3 days)
    const today = new Date();
    const tomorrow = new Date(today);
    tomorrow.setDate(tomorrow.getDate() + 1);

    const returnDate = new Date(tomorrow);
    returnDate.setDate(returnDate.getDate() + 3);

    const formatDateVal = (d) => d.toISOString().split('T')[0];

    // Format human-friendly display text for the pick-up dock segment
    function updatePickupDisplay() {
        if (!pickupDateDisplay || !pickupDateInput) return;
        const dateVal = pickupDateInput.value;
        const timeVal = pickupTimeSelect ? pickupTimeSelect.value : '10:00';
        if (!dateVal) {
            pickupDateDisplay.value = 'Choose date & time';
            return;
        }

        try {
            const [y, m, d] = dateVal.split('-').map(Number);
            const dateObj = new Date(y, m - 1, d);
            
            const now = new Date();
            now.setHours(0, 0, 0, 0);
            const target = new Date(y, m - 1, d);
            target.setHours(0, 0, 0, 0);
            
            const diffDays = Math.round((target - now) / (1000 * 60 * 60 * 24));
            let dateStr = '';
            if (diffDays === 0) {
                dateStr = 'Today';
            } else if (diffDays === 1) {
                dateStr = 'Tomorrow';
            } else {
                dateStr = dateObj.toLocaleDateString('en-US', { weekday: 'short', month: 'short', day: 'numeric' });
            }

            let timeStr = '';
            if (timeVal) {
                const [hr, mn] = timeVal.split(':').map(Number);
                const period = hr >= 12 ? 'PM' : 'AM';
                const displayHr = hr % 12 === 0 ? 12 : hr % 12;
                const displayMn = mn < 10 ? `0${mn}` : mn;
                timeStr = `${displayHr}:${displayMn} ${period}`;
            }

            pickupDateDisplay.value = timeStr ? `${dateStr} • ${timeStr}` : dateStr;
        } catch (e) {
            pickupDateDisplay.value = dateVal;
        }
    }

    // Format human-friendly display text for the return dock segment
    function updateReturnDisplay() {
        if (!returnDateDisplay || !returnDateInput) return;
        const dateVal = returnDateInput.value;
        const timeVal = returnTimeSelect ? returnTimeSelect.value : '10:00';
        if (!dateVal) {
            returnDateDisplay.value = 'Choose date & time';
            return;
        }

        try {
            const [y, m, d] = dateVal.split('-').map(Number);
            const dateObj = new Date(y, m - 1, d);
            
            const now = new Date();
            now.setHours(0, 0, 0, 0);
            const target = new Date(y, m - 1, d);
            target.setHours(0, 0, 0, 0);
            
            const diffDays = Math.round((target - now) / (1000 * 60 * 60 * 24));
            let dateStr = '';
            if (diffDays === 0) {
                dateStr = 'Today';
            } else if (diffDays === 1) {
                dateStr = 'Tomorrow';
            } else {
                dateStr = dateObj.toLocaleDateString('en-US', { weekday: 'short', month: 'short', day: 'numeric' });
            }

            let timeStr = '';
            if (timeVal) {
                const [hr, mn] = timeVal.split(':').map(Number);
                const period = hr >= 12 ? 'PM' : 'AM';
                const displayHr = hr % 12 === 0 ? 12 : hr % 12;
                const displayMn = mn < 10 ? `0${mn}` : mn;
                timeStr = `${displayHr}:${displayMn} ${period}`;
            }

            returnDateDisplay.value = timeStr ? `${dateStr} • ${timeStr}` : dateStr;
        } catch (e) {
            returnDateDisplay.value = dateVal;
        }
    }

    // Controls for Floating Popovers (Hidden under Calendar/Vehicle Icons)
    function openPickupPopover() {
        if (!pickupDatePopover || !pickupDateSegment) return;
        closeReturnPopover();
        closeVehiclePopover();
        pickupDatePopover.classList.add('show');
        pickupDateSegment.classList.add('popover-active');
        pickupDateSegment.setAttribute('aria-expanded', 'true');
    }

    function closePickupPopover() {
        if (!pickupDatePopover || !pickupDateSegment) return;
        pickupDatePopover.classList.remove('show');
        pickupDateSegment.classList.remove('popover-active');
        pickupDateSegment.setAttribute('aria-expanded', 'false');
    }

    function togglePickupPopover(e) {
        if (e && e.target && pickupDatePopover && pickupDatePopover.contains(e.target)) {
            return;
        }
        if (pickupDatePopover && pickupDatePopover.classList.contains('show')) {
            closePickupPopover();
        } else {
            openPickupPopover();
        }
    }

    function openReturnPopover() {
        if (!returnDatePopover || !returnDateSegment) return;
        closePickupPopover();
        closeVehiclePopover();
        returnDatePopover.classList.add('show');
        returnDateSegment.classList.add('popover-active');
        returnDateSegment.setAttribute('aria-expanded', 'true');
    }

    function closeReturnPopover() {
        if (!returnDatePopover || !returnDateSegment) return;
        returnDatePopover.classList.remove('show');
        returnDateSegment.classList.remove('popover-active');
        returnDateSegment.setAttribute('aria-expanded', 'false');
    }

    function toggleReturnPopover(e) {
        if (e && e.target && returnDatePopover && returnDatePopover.contains(e.target)) {
            return;
        }
        if (returnDatePopover && returnDatePopover.classList.contains('show')) {
            closeReturnPopover();
        } else {
            openReturnPopover();
        }
    }

    // Vehicle Category Popover Controls
    function openVehiclePopover() {
        if (!vehicleCategoryPopover || !vehicleSegment) return;
        closePickupPopover();
        closeReturnPopover();
        vehicleCategoryPopover.classList.add('show');
        vehicleSegment.classList.add('popover-active');
        vehicleSegment.setAttribute('aria-expanded', 'true');
    }

    function closeVehiclePopover() {
        if (!vehicleCategoryPopover || !vehicleSegment) return;
        vehicleCategoryPopover.classList.remove('show');
        vehicleSegment.classList.remove('popover-active');
        vehicleSegment.setAttribute('aria-expanded', 'false');
    }

    function toggleVehiclePopover(e) {
        if (e && e.target && vehicleCategoryPopover && vehicleCategoryPopover.contains(e.target)) {
            return;
        }
        if (vehicleCategoryPopover && vehicleCategoryPopover.classList.contains('show')) {
            closeVehiclePopover();
        } else {
            openVehiclePopover();
        }
    }

    if (pickupDateSegment) {
        pickupDateSegment.addEventListener('click', togglePickupPopover);
        pickupDateSegment.addEventListener('keydown', (e) => {
            if ((e.key === 'Enter' || e.key === ' ') && !pickupDatePopover.contains(e.target)) {
                e.preventDefault();
                togglePickupPopover();
            }
        });
    }

    if (btnClosePickupPopover) {
        btnClosePickupPopover.addEventListener('click', (e) => {
            e.stopPropagation();
            closePickupPopover();
        });
    }

    if (btnApplyPickupPopover) {
        btnApplyPickupPopover.addEventListener('click', (e) => {
            e.stopPropagation();
            closePickupPopover();
        });
    }

    if (returnDateSegment) {
        returnDateSegment.addEventListener('click', toggleReturnPopover);
        returnDateSegment.addEventListener('keydown', (e) => {
            if ((e.key === 'Enter' || e.key === ' ') && !returnDatePopover.contains(e.target)) {
                e.preventDefault();
                toggleReturnPopover();
            }
        });
    }

    if (btnCloseReturnPopover) {
        btnCloseReturnPopover.addEventListener('click', (e) => {
            e.stopPropagation();
            closeReturnPopover();
        });
    }

    if (btnApplyReturnPopover) {
        btnApplyReturnPopover.addEventListener('click', (e) => {
            e.stopPropagation();
            closeReturnPopover();
        });
    }

    // Whole Vehicle Selection Button Clickable Controls
    if (vehicleSegment) {
        vehicleSegment.addEventListener('click', toggleVehiclePopover);
        vehicleSegment.addEventListener('keydown', (e) => {
            if ((e.key === 'Enter' || e.key === ' ') && !vehicleCategoryPopover.contains(e.target)) {
                e.preventDefault();
                toggleVehiclePopover();
            }
        });
    }

    if (btnCloseVehiclePopover) {
        btnCloseVehiclePopover.addEventListener('click', (e) => {
            e.stopPropagation();
            closeVehiclePopover();
        });
    }

    // Vehicle Option Selection Items
    vehicleOptionItems.forEach((optItem) => {
        optItem.addEventListener('click', (e) => {
            e.stopPropagation();
            const val = optItem.getAttribute('data-value');
            const label = optItem.getAttribute('data-label') || (optItem.querySelector('.vehicle-option-title') ? optItem.querySelector('.vehicle-option-title').textContent : 'All Vehicles');

            vehicleOptionItems.forEach((item) => {
                item.classList.remove('active');
                item.setAttribute('aria-selected', 'false');
            });
            optItem.classList.add('active');
            optItem.setAttribute('aria-selected', 'true');

            if (vehicleCategoryDisplay) {
                vehicleCategoryDisplay.value = label;
            }
            if (vehicleCategorySelect) {
                vehicleCategorySelect.value = val;
                vehicleCategorySelect.dispatchEvent(new Event('change'));
            }

            closeVehiclePopover();
        });

        optItem.addEventListener('keydown', (e) => {
            if (e.key === 'Enter' || e.key === ' ') {
                e.preventDefault();
                optItem.click();
            }
        });
    });

    // Close when clicking outside or pressing Escape
    document.addEventListener('click', (e) => {
        if (pickupDateSegment && !pickupDateSegment.contains(e.target)) {
            closePickupPopover();
        }
        if (returnDateSegment && !returnDateSegment.contains(e.target)) {
            closeReturnPopover();
        }
        if (vehicleSegment && !vehicleSegment.contains(e.target)) {
            closeVehiclePopover();
        }
    });

    document.addEventListener('keydown', (e) => {
        if (e.key === 'Escape') {
            closePickupPopover();
            closeReturnPopover();
            closeVehiclePopover();
        }
    });

    if (pickupDateInput && returnDateInput) {
        pickupDateInput.min = formatDateVal(today);
        pickupDateInput.value = formatDateVal(tomorrow);

        returnDateInput.min = formatDateVal(tomorrow);
        returnDateInput.value = formatDateVal(returnDate);

        updatePickupDisplay();
        updateReturnDisplay();

        // Sync minimum return date with selected pickup date
        pickupDateInput.addEventListener('change', () => {
            updatePickupDisplay();
            if (pickupDateInput.value) {
                returnDateInput.min = pickupDateInput.value;
                if (returnDateInput.value < pickupDateInput.value) {
                    const newReturn = new Date(pickupDateInput.value);
                    newReturn.setDate(newReturn.getDate() + 2);
                    returnDateInput.value = formatDateVal(newReturn);
                    updateReturnDisplay();
                }
            }
        });

        if (pickupTimeSelect) {
            pickupTimeSelect.addEventListener('change', updatePickupDisplay);
        }

        returnDateInput.addEventListener('change', () => {
            updateReturnDisplay();
        });

        if (returnTimeSelect) {
            returnTimeSelect.addEventListener('change', updateReturnDisplay);
        }
    }

    // Highlight text helper
    function highlightQuery(text, query) {
        if (!query) return text;
        const escaped = query.replace(/[.*+?^${}()|[\]\\]/g, '\\$&');
        const regex = new RegExp(`(${escaped})`, 'gi');
        return text.replace(regex, '<span class="match-highlight">$1</span>');
    }

    // Render detailed suggestions inside centered popup modal
    function renderDetailedModalSuggestions() {
        if (!modalSuggestionsContainer) return;
        const query = (modalSearchInput ? modalSearchInput.value : '').trim().toLowerCase();

        const filtered = STORED_LOCATIONS.filter((loc) => {
            // Category check
            let matchesCat = false;
            if (currentCategoryFilter === 'all') matchesCat = true;
            else if (currentCategoryFilter === 'airport') matchesCat = loc.category === 'airport';
            else if (currentCategoryFilter === 'city') matchesCat = loc.category === 'city';
            else if (currentCategoryFilter === 'instant') matchesCat = loc.isInstant === true;

            // Search query check (name, code, subtitle)
            const matchesQuery = !query ||
                loc.name.toLowerCase().includes(query) ||
                loc.code.toLowerCase().includes(query) ||
                loc.subtitle.toLowerCase().includes(query);

            return matchesCat && matchesQuery;
        });

        if (modalLocationCount) {
            modalLocationCount.textContent = `Showing ${filtered.length} locations`;
        }

        if (filtered.length === 0) {
            modalSuggestionsContainer.innerHTML = `
                <div class="no-modal-results">
                    <div class="no-modal-icon">🔎</div>
                    <h5 class="fw-bold text-dark mb-1">No matching locations found</h5>
                    <p class="small text-muted mb-0">Try searching with a city name (e.g. Los Angeles, Miami) or airport code (LAX, SFO, JFK).</p>
                </div>
            `;
            return;
        }

        modalSuggestionsContainer.innerHTML = filtered.map((loc) => {
            const displayName = highlightQuery(loc.name, query);
            const badgeClass = loc.category === 'airport' ? 'airport-badge' : 'city-badge';
            const perksHtml = loc.perks.map((p) => `<span class="card-perk-pill">${p}</span>`).join('');

            return `
                <div class="detailed-suggestion-card" data-name="${loc.name}" role="option" tabindex="0">
                    <div class="suggestion-card-left">
                        <div class="category-code-badge ${badgeClass}">
                            <span class="badge-icon">${loc.icon}</span>
                            <span class="badge-code">${loc.code}</span>
                        </div>
                    </div>
                    <div class="suggestion-card-main">
                        <div class="card-location-title-row">
                            <h4 class="card-location-name">${displayName}</h4>
                            <span class="card-rating-tag">${loc.rating}</span>
                        </div>
                        <p class="card-address">${loc.subtitle}</p>
                        <div class="card-perks-row">
                            ${perksHtml}
                        </div>
                    </div>
                    <div class="suggestion-card-right">
                        <span class="card-cars-count">${loc.cars}</span>
                        <button type="button" class="btn-card-select">Select ➔</button>
                    </div>
                </div>
            `;
        }).join('');

        // Attach click listeners to cards
        modalSuggestionsContainer.querySelectorAll('.detailed-suggestion-card').forEach((card) => {
            const handleSelect = () => {
                const selectedLocationName = card.getAttribute('data-name');
                applyLocationSelection(selectedLocationName);
            };

            card.addEventListener('click', handleSelect);
            card.addEventListener('keydown', (e) => {
                if (e.key === 'Enter' || e.key === ' ') {
                    e.preventDefault();
                    handleSelect();
                }
            });
        });
    }

    // Apply chosen location to target input
    function applyLocationSelection(locationName) {
        if (currentTarget === 'pickup') {
            if (pickupInput) pickupInput.value = locationName;
            // If toggle "same as pickup" is active, also fill dropoff
            if (toggleSameBtn && toggleSameBtn.classList.contains('active')) {
                if (dropoffInput) dropoffInput.value = locationName;
            }
        } else if (currentTarget === 'dropoff') {
            if (dropoffInput) dropoffInput.value = locationName;
            if (toggleSameBtn) toggleSameBtn.classList.remove('active');
        }

        closeLocationModal();
    }

    // Open Modal Function (with background blur)
    function openLocationModal(targetType) {
        currentTarget = targetType;
        if (modalTitle) {
            modalTitle.textContent = targetType === 'pickup'
                ? 'Select Pick-up Location'
                : 'Select Drop-off Location';
        }

        if (modalSearchInput) {
            modalSearchInput.value = '';
        }
        if (btnClearSearch) {
            btnClearSearch.classList.add('d-none');
        }

        // Reset filter chips to 'all'
        currentCategoryFilter = 'all';
        modalFilterChips.forEach((chip) => {
            chip.classList.toggle('active', chip.getAttribute('data-filter') === 'all');
        });

        renderDetailedModalSuggestions();

        if (modalOverlay) {
            modalOverlay.classList.add('active');
            modalOverlay.setAttribute('aria-hidden', 'false');
            document.body.classList.add('modal-open');
        }

        setTimeout(() => {
            if (modalSearchInput) modalSearchInput.focus();
        }, 120);
    }

    // Close Modal Function
    function closeLocationModal() {
        if (modalOverlay) {
            modalOverlay.classList.remove('active');
            modalOverlay.setAttribute('aria-hidden', 'true');
            document.body.classList.remove('modal-open');
        }
    }

    // Event Listeners to Open Modal from Segments
    if (pickupSegment) {
        pickupSegment.addEventListener('click', (e) => {
            e.preventDefault();
            openLocationModal('pickup');
        });
        pickupSegment.addEventListener('keydown', (e) => {
            if (e.key === 'Enter' || e.key === ' ') {
                e.preventDefault();
                openLocationModal('pickup');
            }
        });
    }

    if (dropoffSegment) {
        dropoffSegment.addEventListener('click', (e) => {
            // Prevent triggering modal if clicking the toggle button directly
            if (e.target.closest('#toggleSameLocation')) return;
            e.preventDefault();
            openLocationModal('dropoff');
        });
        dropoffSegment.addEventListener('keydown', (e) => {
            if (e.target.closest('#toggleSameLocation')) return;
            if (e.key === 'Enter' || e.key === ' ') {
                e.preventDefault();
                openLocationModal('dropoff');
            }
        });
    }

    // "Same as pickup" Quick Toggle Button
    if (toggleSameBtn && pickupInput && dropoffInput) {
        toggleSameBtn.addEventListener('click', (e) => {
            e.stopPropagation();
            toggleSameBtn.classList.toggle('active');
            if (toggleSameBtn.classList.contains('active')) {
                if (pickupInput.value) {
                    dropoffInput.value = pickupInput.value;
                } else {
                    dropoffInput.placeholder = 'Same as pick-up';
                }
            } else {
                dropoffInput.value = '';
                dropoffInput.placeholder = 'Choose city or airport...';
            }
        });
    }

    // Close Modal Listeners
    if (btnCloseModal) {
        btnCloseModal.addEventListener('click', closeLocationModal);
    }

    // Close on clicking backdrop outside dialog card
    if (modalOverlay) {
        modalOverlay.addEventListener('click', (e) => {
            if (!e.target.closest('.location-modal-dialog')) {
                closeLocationModal();
            }
        });
    }

    // Close on Escape key
    document.addEventListener('keydown', (e) => {
        if (e.key === 'Escape' && modalOverlay && modalOverlay.classList.contains('active')) {
            closeLocationModal();
        }
    });

    // Modal Search Input listener
    if (modalSearchInput) {
        modalSearchInput.addEventListener('input', () => {
            if (btnClearSearch) {
                btnClearSearch.classList.toggle('d-none', !modalSearchInput.value);
            }
            renderDetailedModalSuggestions();
        });
    }

    // Clear search button
    if (btnClearSearch && modalSearchInput) {
        btnClearSearch.addEventListener('click', () => {
            modalSearchInput.value = '';
            btnClearSearch.classList.add('d-none');
            modalSearchInput.focus();
            renderDetailedModalSuggestions();
        });
    }

    // Category Filter Chips
    modalFilterChips.forEach((chip) => {
        chip.addEventListener('click', () => {
            modalFilterChips.forEach((c) => c.classList.remove('active'));
            chip.classList.add('active');
            currentCategoryFilter = chip.getAttribute('data-filter');
            renderDetailedModalSuggestions();
        });
    });

    // Handle "Search Cars" Action Button
    if (searchBtn) {
        searchBtn.addEventListener('click', () => {
            const pickupVal = pickupInput ? pickupInput.value.trim() : '';
            const dropoffVal = dropoffInput && dropoffInput.value.trim() ? dropoffInput.value.trim() : pickupVal;
            const pDate = pickupDateInput ? pickupDateInput.value : '';
            const pTime = pickupTimeSelect ? pickupTimeSelect.options[pickupTimeSelect.selectedIndex].text : '';
            const rDate = returnDateInput ? returnDateInput.value : '';
            const rTime = returnTimeSelect ? returnTimeSelect.options[returnTimeSelect.selectedIndex].text : '';
            const vehicleVal = vehicleCategorySelect ? vehicleCategorySelect.options[vehicleCategorySelect.selectedIndex].text : 'All Vehicles';

            if (!pickupVal) {
                // Open modal immediately to guide user
                openLocationModal('pickup');
                return;
            }

            // Show Feedback Toast with results
            if (feedbackToast && toastTitle && toastDesc) {
                toastTitle.textContent = `⚡ 38 Available Vehicles Found!`;
                toastDesc.innerHTML = `
                    <strong>${pickupVal}</strong> ➔ <strong>${dropoffVal || pickupVal}</strong><br/>
                    📅 ${pDate} (${pTime}) to ${rDate} (${rTime}) • <em>${vehicleVal}</em>
                `;
                feedbackToast.classList.remove('d-none');

                setTimeout(() => {
                    feedbackToast.classList.add('d-none');
                }, 6000);
            }
        });
    }

    // Close toast button
    if (btnCloseToast && feedbackToast) {
        btnCloseToast.addEventListener('click', () => {
            feedbackToast.classList.add('d-none');
        });
    }

    // Smooth navigation anchor for "Reserve Now" buttons across page
    document.querySelectorAll('a[href="#book"]').forEach((anchor) => {
        anchor.addEventListener('click', (e) => {
            e.preventDefault();
            const bookSection = document.getElementById('book');
            if (bookSection) {
                bookSection.scrollIntoView({ behavior: 'smooth', block: 'center' });
                setTimeout(() => {
                    openLocationModal('pickup');
                }, 400);
            }
        });
    });
});


