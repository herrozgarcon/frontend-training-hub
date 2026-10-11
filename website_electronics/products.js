// Product catalog for Tronics Electronics Store
const products = [
    {
        id: "sony-wh1000xm5",
        name: "Sony WH-1000XM5 Wireless Headphones",
        tagline: "Industry-Leading Noise Cancelling",
        category: "Audio",
        badge: "Best Seller",
        rating: 4.8,
        reviewsCount: 1420,
        price: 349.99,
        originalPrice: 399.99,
        image: "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=800&auto=format&fit=crop&q=80",
        additionalImages: [
            "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=800&auto=format&fit=crop&q=80",
            "https://images.unsplash.com/photo-1583394838336-acd977736f90?w=800&auto=format&fit=crop&q=80",
            "https://images.unsplash.com/photo-1484704849700-f032a568e944?w=800&auto=format&fit=crop&q=80"
        ],
        shortDescription: "Flagship wireless noise-cancelling headphones with 2 processors, 8 microphones, and ultra-comfortable lightweight design.",
        detailedDescription: "The WH-1000XM5 headphones rewrite the rules for distraction-free listening. Two processors control 8 microphones for unprecedented noise cancellation and exceptional call quality. Newly developed 30mm precision-engineered drivers deliver magnificent high-resolution audio with crystal clear vocals.",
        features: [
            "Industry-leading active noise cancellation (Auto NC Optimizer)",
            "Magnificent sound engineered with new 30mm carbon fiber driver",
            "Crystal clear hands-free calling with 4 beamforming microphones",
            "Up to 30 hours of battery life with quick 3-min charging (3 hours playback)",
            "Multipoint connection allows pairing with two Bluetooth devices simultaneously"
        ],
        specs: {
            "Brand": "Sony",
            "Model": "WH-1000XM5",
            "Color": "Silver / Midnight Black",
            "Battery Life": "Up to 30 Hours (NC On)",
            "Connectivity": "Bluetooth 5.2 / 3.5mm Aux",
            "Weight": "250g",
            "Warranty": "1 Year Official Warranty"
        },
        inStock: true,
        stockCount: 18
    },
    {
        id: "macbook-pro-16-m3",
        name: "Apple MacBook Pro 16\" M3 Max",
        tagline: "Mind-Blowing. Head-Turning.",
        category: "Laptops",
        badge: "Staff Pick",
        rating: 4.9,
        reviewsCount: 940,
        price: 2499.00,
        originalPrice: 2699.00,
        image: "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?w=800&auto=format&fit=crop&q=80",
        additionalImages: [
            "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?w=800&auto=format&fit=crop&q=80",
            "https://images.unsplash.com/photo-1611186871348-b1ce696e52c9?w=800&auto=format&fit=crop&q=80",
            "https://images.unsplash.com/photo-1541807084-5c52b6b3adef?w=800&auto=format&fit=crop&q=80"
        ],
        shortDescription: "Supercharged by M3 Max with up to 16-core CPU, 40-core GPU, stunning Liquid Retina XDR display, and up to 22 hours battery.",
        detailedDescription: "MacBook Pro blasts forward with M3 Max, an extraordinarily advanced chip that powers complex 3D rendering, machine learning modeling, and 8K multi-stream editing. Featuring the brilliant Liquid Retina XDR display, 1080p FaceTime HD camera, and immersive six-speaker sound system with Spatial Audio.",
        features: [
            "Apple M3 Max chip with 16-core CPU and 40-core GPU",
            "Stunning 16.2-inch Liquid Retina XDR display with ProMotion 120Hz",
            "36GB Unified Memory and 1TB ultra-fast SSD storage",
            "Up to 22 hours battery life — the longest ever in a Mac",
            "Three Thunderbolt 4 ports, HDMI port, SDXC card slot, MagSafe 3"
        ],
        specs: {
            "Brand": "Apple",
            "Processor": "Apple M3 Max",
            "RAM": "36GB Unified Memory",
            "Storage": "1TB NVMe SSD",
            "Display": "16.2\" Liquid Retina XDR (3456 x 2234)",
            "Battery": "Up to 22 Hours",
            "Warranty": "1 Year AppleCare Warranty"
        },
        inStock: true,
        stockCount: 7
    },
    {
        id: "samsung-galaxy-s24-ultra",
        name: "Samsung Galaxy S24 Ultra 5G",
        tagline: "Galaxy AI is Here",
        category: "Smartphones",
        badge: "New Release",
        rating: 4.7,
        reviewsCount: 2150,
        price: 1199.99,
        originalPrice: 1299.99,
        image: "https://images.unsplash.com/photo-1610945265064-0e34e5519bbf?w=800&auto=format&fit=crop&q=80",
        additionalImages: [
            "https://images.unsplash.com/photo-1610945265064-0e34e5519bbf?w=800&auto=format&fit=crop&q=80",
            "https://images.unsplash.com/photo-1598327105666-5b89351aff97?w=800&auto=format&fit=crop&q=80",
            "https://images.unsplash.com/photo-1580910051074-3eb694886505?w=800&auto=format&fit=crop&q=80"
        ],
        shortDescription: "Titanium exterior, flat 6.8\" Dynamic AMOLED 2X, embedded S Pen, and revolutionary 200MP camera system powered by Galaxy AI.",
        detailedDescription: "Unleash whole new levels of creativity, productivity, and possibility with Galaxy S24 Ultra. Built with a sleek titanium shield, Corning Gorilla Armor glass, and driven by Snapdragon 8 Gen 3 with on-device generative AI features like Circle to Search, Live Translate, and Generative Photo Edit.",
        features: [
            "Galaxy AI Suite: Live Call Translate, Note Assist, Generative Photo Edit",
            "200MP Quad Telephoto Camera with 100x Space Zoom & ProVisual Engine",
            "Durable Titanium frame with Corning Gorilla Armor scratch resistance",
            "Built-in S Pen for precise note taking, drawing, and remote gestures",
            "5,000 mAh battery with intelligent all-day power management"
        ],
        specs: {
            "Brand": "Samsung",
            "Display": "6.8\" Dynamic AMOLED 2X 120Hz (2600 nits)",
            "Processor": "Snapdragon 8 Gen 3 for Galaxy",
            "RAM / Storage": "12GB RAM / 256GB Storage",
            "Camera": "200MP + 50MP + 12MP + 10MP",
            "Battery": "5000 mAh Super Fast Charge 2.0",
            "Warranty": "1 Year Manufacturer Warranty"
        },
        inStock: true,
        stockCount: 24
    },
    {
        id: "apple-watch-ultra-2",
        name: "Apple Watch Ultra 2 GPS + Cellular",
        tagline: "The Ultimate Sports & Adventure Watch",
        category: "Wearables",
        badge: "Popular",
        rating: 4.9,
        reviewsCount: 880,
        price: 799.00,
        originalPrice: 849.00,
        image: "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=800&auto=format&fit=crop&q=80",
        additionalImages: [
            "https://images.unsplash.com/photo-1523275335684-37898b6baf30?w=800&auto=format&fit=crop&q=80",
            "https://images.unsplash.com/photo-1508685096489-7aacd43bd3b1?w=800&auto=format&fit=crop&q=80",
            "https://images.unsplash.com/photo-1546868871-7041f2a55e12?w=800&auto=format&fit=crop&q=80"
        ],
        shortDescription: "Corrosion-resistant 49mm titanium case, 3000 nits always-on Retina display, customizable Action button, and 36-hour battery.",
        detailedDescription: "Built for endurance athletes, outdoor explorers, and water sports enthusiasts. Apple Watch Ultra 2 features precision dual-frequency GPS, depth gauge and water temperature sensor, siren emergency feature, and the ultra-bright 3000 nits display visible under direct blinding sunlight.",
        features: [
            "Rugged aerospace-grade 49mm titanium case with raised sapphire crystal",
            "Brightest display ever at 3,000 nits with Night Mode activation",
            "Precision dual-frequency GPS for accurate distance, pace, and route maps",
            "100m water resistance, EN13319 certified for recreational scuba diving to 40m",
            "Double tap gesture to easily interact without touching the screen"
        ],
        specs: {
            "Brand": "Apple",
            "Case Size": "49mm Aerospace Titanium",
            "Display": "Always-On Retina OLED (3000 nits)",
            "Battery": "Up to 36 hours (72 hours Low Power)",
            "Connectivity": "LTE Cellular + GPS + Wi-Fi + Bluetooth 5.3",
            "Water Rating": "100m Water Resistant / IP6X Dust Resistant",
            "Warranty": "1 Year Apple Warranty"
        },
        inStock: true,
        stockCount: 12
    },
    {
        id: "sony-playstation-5-pro",
        name: "PlayStation 5 Pro Digital Edition",
        tagline: "Witness Play Unleashed",
        category: "Gaming",
        badge: "Hot Item",
        rating: 4.8,
        reviewsCount: 3100,
        price: 699.99,
        originalPrice: 749.99,
        image: "https://images.unsplash.com/photo-1606813907291-d86efa9b94db?w=800&auto=format&fit=crop&q=80",
        additionalImages: [
            "https://images.unsplash.com/photo-1606813907291-d86efa9b94db?w=800&auto=format&fit=crop&q=80",
            "https://images.unsplash.com/photo-1607604276583-eef5d076aa5f?w=800&auto=format&fit=crop&q=80",
            "https://images.unsplash.com/photo-1579586337278-3befd40fd17a?w=800&auto=format&fit=crop&q=80"
        ],
        shortDescription: "Upgraded GPU with PlayStation Spectral Super Resolution (PSSR), advanced ray tracing, and high framerates at 4K resolution.",
        detailedDescription: "The PS5 Pro console allows creators to enhance games with incredible ray tracing features, super sharp image clarity via AI upscaling, and buttery smooth gameplay up to 120 FPS. Comes with 2TB high-speed solid-state drive pre-installed.",
        features: [
            "PlayStation Spectral Super Resolution (PSSR) AI-driven image upscaling",
            "Advanced Ray Tracing provides dynamic reflections and realistic lighting",
            "Pre-installed 2TB ultra-high speed internal NVMe SSD",
            "Supports 4K 120Hz and 8K display output with VRR support",
            "Includes DualSense wireless controller with adaptive triggers and haptic feedback"
        ],
        specs: {
            "Brand": "Sony PlayStation",
            "Storage": "2TB Custom NVMe SSD",
            "Output": "4K 120Hz / 8K / HDR / VRR",
            "Audio": "Tempest 3D AudioTech",
            "Network": "Wi-Fi 7 Ready, Gigabit Ethernet",
            "Warranty": "1 Year Official PlayStation Warranty"
        },
        inStock: true,
        stockCount: 9
    },
    {
        id: "fujifilm-xt5",
        name: "Fujifilm X-T5 Mirrorless Camera Body",
        tagline: "Photography First",
        category: "Cameras",
        badge: "Top Rated",
        rating: 4.9,
        reviewsCount: 520,
        price: 1699.00,
        originalPrice: 1799.00,
        image: "https://images.unsplash.com/photo-1516035069371-29a1b244cc32?w=800&auto=format&fit=crop&q=80",
        additionalImages: [
            "https://images.unsplash.com/photo-1516035069371-29a1b244cc32?w=800&auto=format&fit=crop&q=80",
            "https://images.unsplash.com/photo-1502982720700-bfff97f2ecac?w=800&auto=format&fit=crop&q=80",
            "https://images.unsplash.com/photo-1512790182412-b19e6d62bc39?w=800&auto=format&fit=crop&q=80"
        ],
        shortDescription: "40.2MP X-Trans CMOS 5 HR sensor, 5-axis 7.0-stop in-body stabilization, 6.2K 30p video, and iconic analog dials.",
        detailedDescription: "A photographer's dream. The X-T5 blends compact retro design with a 40.2-megapixel sensor that captures jaw-dropping fine detail. With 19 Film Simulation modes, pixel-shift multi-shot 160MP composite mode, and triple-tilt LCD screen.",
        features: [
            "40.2 Megapixel back-illuminated X-Trans CMOS 5 HR imaging sensor",
            "7.0 stops 5-axis in-body image stabilization (IBIS)",
            "Up to 1/180,000 sec electronic shutter speed with freeze-frame precision",
            "6.2K/30p 4:2:2 10-bit internal video recording with F-Log2",
            "Dual SD UHS-II card slots and weather-resistant magnesium alloy body"
        ],
        specs: {
            "Brand": "Fujifilm",
            "Sensor": "40.2MP APS-C X-Trans CMOS 5 HR",
            "Stabilization": "5-axis IBIS up to 7 stops",
            "Video": "6.2K/30p, 4K/60p, FHD/240p",
            "Card Slots": "Dual SD UHS-II",
            "Weight": "557g (with battery & memory)",
            "Warranty": "2 Years Manufacturer Warranty"
        },
        inStock: true,
        stockCount: 5
    },
    {
        id: "sonos-era-300",
        name: "Sonos Era 300 Smart Speaker",
        tagline: "Feel Sound All Around",
        category: "Audio",
        badge: "Spatial Audio",
        rating: 4.7,
        reviewsCount: 790,
        price: 449.00,
        originalPrice: 499.00,
        image: "https://images.unsplash.com/photo-1545454675-3531b543be5d?w=800&auto=format&fit=crop&q=80",
        additionalImages: [
            "https://images.unsplash.com/photo-1545454675-3531b543be5d?w=800&auto=format&fit=crop&q=80",
            "https://images.unsplash.com/photo-1543512214-318c7553f230?w=800&auto=format&fit=crop&q=80",
            "https://images.unsplash.com/photo-1508700115892-45ecd05ae2ad?w=800&auto=format&fit=crop&q=80"
        ],
        shortDescription: "Revolutionary acoustic design with 6 drivers calibrated for Dolby Atmos Spatial Audio, WiFi 6, and Bluetooth streaming.",
        detailedDescription: "Featuring six optimally positioned drivers all around the front, sides, and top to support Dolby Atmos Music, Era 300 bounces sound from wall to wall and floor to ceiling, immersing you in every dimension of the song.",
        features: [
            "Dolby Atmos spatial audio with room-filling panoramic soundstage",
            "Six class-D digital amplifiers powered by custom drivers & tweeters",
            "Trueplay tuning technology optimizes sound for the room's unique acoustics",
            "Dual connectivity: High-resolution Wi-Fi 6 streaming and Bluetooth 5.0",
            "Works with Amazon Alexa, Apple AirPlay 2, and Sonos Voice Control"
        ],
        specs: {
            "Brand": "Sonos",
            "Audio Tech": "Dolby Atmos Spatial Audio, 6 Custom Drivers",
            "Connectivity": "Wi-Fi 6, Bluetooth 5.0, USB-C Line-In",
            "Voice Assistant": "Alexa Built-in & Sonos Voice",
            "Dimensions": "160 x 260 x 185 mm",
            "Warranty": "1 Year Sonos Warranty"
        },
        inStock: true,
        stockCount: 15
    },
    {
        id: "dji-mini-4-pro",
        name: "DJI Mini 4 Pro Fly More Combo Plus",
        tagline: "Mini to the Max",
        category: "Drones",
        badge: "Top Rated",
        rating: 4.8,
        reviewsCount: 640,
        price: 1099.00,
        originalPrice: 1159.00,
        image: "https://images.unsplash.com/photo-1527977966376-1c8408f9f108?w=800&auto=format&fit=crop&q=80",
        additionalImages: [
            "https://images.unsplash.com/photo-1527977966376-1c8408f9f108?w=800&auto=format&fit=crop&q=80",
            "https://images.unsplash.com/photo-1508614589041-895b88991e3e?w=800&auto=format&fit=crop&q=80",
            "https://images.unsplash.com/photo-1473968512647-3e447244af8f?w=800&auto=format&fit=crop&q=80"
        ],
        shortDescription: "Ultra-lightweight under 249g foldable drone with omnidirectional obstacle sensing, 4K/60fps HDR, and 20km video transmission.",
        detailedDescription: "Take flight whenever inspiration strikes. DJI Mini 4 Pro integrates powerful imaging capabilities, omnidirectional obstacle sensing, ActiveTrack 360°, and flagship O4 FHD video transmission. Ultra-lightweight with no registration required in most regions.",
        features: [
            "Reg-friendly under 249 grams lightweight folding design",
            "Omnidirectional obstacle sensing with APAS 5.0 safety automation",
            "4K/60fps HDR True Vertical Shooting for direct social media sharing",
            "Up to 45 minutes extended flight time with Intelligent Flight Battery Plus",
            "Flagship DJI O4 video transmission up to 20 km FHD range"
        ],
        specs: {
            "Brand": "DJI",
            "Takeoff Weight": "< 249 g",
            "Max Flight Time": "Up to 45 mins (Plus Battery)",
            "Max Transmission": "20 km FHD (DJI O4)",
            "Sensor": "1/1.3-inch CMOS, f/1.7 aperture",
            "Warranty": "1 Year DJI Care Express"
        },
        inStock: true,
        stockCount: 11
    }
];

// Helper functions for cart state
const Cart = {
    getItems() {
        try {
            return JSON.parse(localStorage.getItem('tronics_cart') || '[]');
        } catch (e) {
            return [];
        }
    },
    save(items) {
        localStorage.setItem('tronics_cart', JSON.stringify(items));
        window.dispatchEvent(new CustomEvent('cart-updated', { detail: items }));
    },
    add(product, qty = 1) {
        const items = this.getItems();
        const existing = items.find(i => i.id === product.id);
        if (existing) {
            existing.quantity = (existing.quantity || 1) + qty;
        } else {
            items.push({
                id: product.id,
                name: product.name,
                price: product.price,
                image: product.image,
                quantity: qty
            });
        }
        this.save(items);
        return items;
    },
    getCount() {
        return this.getItems().reduce((total, item) => total + (item.quantity || 1), 0);
    }
};

// UI Toast Notification helper
function showToast(message, type = 'success') {
    let container = document.getElementById('toast-container');
    if (!container) {
        container = document.createElement('div');
        container.id = 'toast-container';
        container.className = 'toast-container-custom';
        document.body.appendChild(container);
    }

    const toast = document.createElement('div');
    toast.className = `custom-toast custom-toast-${type}`;
    const icon = type === 'success' ? 'bi-check-circle-fill' : 'bi-info-circle-fill';
    toast.innerHTML = `
        <i class="bi ${icon}"></i>
        <span>${message}</span>
    `;
    container.appendChild(toast);

    setTimeout(() => {
        toast.classList.add('show');
    }, 10);

    setTimeout(() => {
        toast.classList.remove('show');
        setTimeout(() => toast.remove(), 400);
    }, 3200);
}

// Update cart badges across pages
function updateCartBadges() {
    const badges = document.querySelectorAll('.cart-badge-count');
    const count = Cart.getCount();
    badges.forEach(badge => {
        badge.textContent = count;
        badge.style.display = count > 0 ? 'inline-flex' : 'none';
    });
}

window.addEventListener('DOMContentLoaded', updateCartBadges);
window.addEventListener('cart-updated', updateCartBadges);

// Helper to escape HTML characters safely
function escapeHtml(str) {
    if (!str) return '';
    return String(str)
        .replace(/&/g, '&amp;')
        .replace(/</g, '&lt;')
        .replace(/>/g, '&gt;')
        .replace(/"/g, '&quot;')
        .replace(/'/g, '&#39;');
}

// ==========================================
// Product Search & Auto-Suggestions Engine
// ==========================================
function initSearch() {
    const searchForms = document.querySelectorAll('form[role="search"]');
    if (!searchForms.length) return;

    searchForms.forEach(form => {
        const input = form.querySelector('input[type="search"]') || form.querySelector('input');
        if (!input) return;

        form.classList.add('search-form');

        // Wrap input in search-input-wrapper if not wrapped
        let wrapper = input.parentElement;
        if (!wrapper || !wrapper.classList.contains('search-input-wrapper')) {
            wrapper = document.createElement('div');
            wrapper.className = 'search-input-wrapper position-relative flex-grow-1 me-2';
            input.parentNode.insertBefore(wrapper, input);
            wrapper.appendChild(input);
        }

        // Suggestions dropdown container
        let dropdown = wrapper.querySelector('.search-suggestions-dropdown');
        if (!dropdown) {
            dropdown = document.createElement('div');
            dropdown.className = 'search-suggestions-dropdown';
            wrapper.appendChild(dropdown);
        }

        let selectedIndex = -1;

        // Categories from product data
        const categories = Array.from(new Set(products.map(p => p.category)));

        function renderSuggestions(query) {
            const trimmed = (query || '').trim().toLowerCase();
            selectedIndex = -1;

            if (!trimmed) {
                // General suggestions when input is empty or on focus
                let html = `
                    <div class="search-section-header">Popular Categories</div>
                    <div class="px-3 pb-2 pt-1 d-flex flex-wrap gap-1">
                `;
                categories.forEach(cat => {
                    html += `<span class="search-tag-chip" data-search-term="${escapeHtml(cat)}">${escapeHtml(cat)}</span>`;
                });
                html += `
                    </div>
                    <div class="search-section-header">Trending Products</div>
                `;

                // Show top 3 products as suggestions
                const trending = products.slice(0, 3);
                trending.forEach(item => {
                    html += `
                        <div class="search-suggestion-item" data-product-id="${item.id}">
                            <img src="${item.image}" alt="${escapeHtml(item.name)}">
                            <div class="search-suggestion-info">
                                <div class="search-suggestion-title">${escapeHtml(item.name)}</div>
                                <div class="search-suggestion-meta">
                                    <span class="badge bg-light text-dark border">${escapeHtml(item.category)}</span>
                                    <span>${escapeHtml(item.specs && item.specs.Brand ? item.specs.Brand : '')}</span>
                                </div>
                            </div>
                            <div class="search-suggestion-price">$${item.price.toFixed(2)}</div>
                        </div>
                    `;
                });
                dropdown.innerHTML = html;
                dropdown.style.display = 'block';
                attachDropdownItemListeners();
                return;
            }

            // Filter products matching query
            const matchedProducts = products.filter(p => {
                const name = p.name.toLowerCase();
                const cat = p.category.toLowerCase();
                const tag = (p.tagline || '').toLowerCase();
                const desc = (p.shortDescription || '').toLowerCase();
                const brand = (p.specs && p.specs.Brand ? p.specs.Brand : '').toLowerCase();
                return name.includes(trimmed) || cat.includes(trimmed) || tag.includes(trimmed) || desc.includes(trimmed) || brand.includes(trimmed);
            });

            // Filter matching categories
            const matchedCats = categories.filter(c => c.toLowerCase().includes(trimmed));

            let html = '';

            if (matchedCats.length > 0) {
                html += `
                    <div class="search-section-header">Matching Categories</div>
                    <div class="px-3 pb-2 pt-1 d-flex flex-wrap gap-1">
                `;
                matchedCats.forEach(cat => {
                    html += `<span class="search-tag-chip" data-search-term="${escapeHtml(cat)}">${escapeHtml(cat)}</span>`;
                });
                html += `</div>`;
            }

            if (matchedProducts.length > 0) {
                html += `<div class="search-section-header">Products (${matchedProducts.length})</div>`;
                matchedProducts.slice(0, 5).forEach(item => {
                    const regex = new RegExp(`(${trimmed.replace(/[.*+?^${}()|[\]\\]/g, '\\$&')})`, 'gi');
                    const highlightedName = escapeHtml(item.name).replace(regex, '<span class="text-primary fw-bold">$1</span>');

                    html += `
                        <div class="search-suggestion-item" data-product-id="${item.id}">
                            <img src="${item.image}" alt="${escapeHtml(item.name)}">
                            <div class="search-suggestion-info">
                                <div class="search-suggestion-title">${highlightedName}</div>
                                <div class="search-suggestion-meta">
                                    <span class="badge bg-light text-dark border">${escapeHtml(item.category)}</span>
                                    <span>${escapeHtml(item.tagline || '')}</span>
                                </div>
                            </div>
                            <div class="search-suggestion-price">$${item.price.toFixed(2)}</div>
                        </div>
                    `;
                });

                html += `
                    <div class="search-view-all" data-search-term="${escapeHtml(query)}">
                        Show all ${matchedProducts.length} results for "<strong>${escapeHtml(query)}</strong>" (Press Enter)
                    </div>
                `;
            } else {
                html += `
                    <div class="p-3 text-center text-muted">
                        <div class="small fw-semibold mb-1">No products found for "${escapeHtml(query)}"</div>
                        <div style="font-size: 0.78rem;">Try searching: laptops, headphones, apple, sony, audio...</div>
                    </div>
                `;
            }

            dropdown.innerHTML = html;
            dropdown.style.display = 'block';
            attachDropdownItemListeners();
        }

        function attachDropdownItemListeners() {
            // Tag chips
            dropdown.querySelectorAll('.search-tag-chip').forEach(chip => {
                chip.addEventListener('click', (e) => {
                    e.stopPropagation();
                    const term = chip.getAttribute('data-search-term');
                    input.value = term;
                    executeSearch(term);
                });
            });

            // Product items
            dropdown.querySelectorAll('.search-suggestion-item').forEach(item => {
                item.addEventListener('click', (e) => {
                    e.stopPropagation();
                    const id = item.getAttribute('data-product-id');
                    if (id) {
                        window.location.href = `product-detail.html?id=${encodeURIComponent(id)}`;
                    }
                });
            });

            // View all button
            const viewAll = dropdown.querySelector('.search-view-all');
            if (viewAll) {
                viewAll.addEventListener('click', (e) => {
                    e.stopPropagation();
                    const term = viewAll.getAttribute('data-search-term');
                    executeSearch(term);
                });
            }
        }

        function hideDropdown() {
            dropdown.style.display = 'none';
            selectedIndex = -1;
        }

        function executeSearch(query) {
            hideDropdown();
            const q = (query !== undefined ? query : input.value).trim();
            const isShopPage = window.location.pathname.endsWith('shop.html') || !!document.getElementById('products-container');

            if (isShopPage && typeof window.filterShopProducts === 'function') {
                window.filterShopProducts(q);
            } else {
                window.location.href = `shop.html?search=${encodeURIComponent(q)}`;
            }
        }

        // Live input typing suggestions
        input.addEventListener('input', () => {
            renderSuggestions(input.value);
        });

        // Focus shows general suggestions
        input.addEventListener('focus', () => {
            renderSuggestions(input.value);
        });

        // Keyboard navigation (ArrowDown, ArrowUp, Enter, Escape)
        input.addEventListener('keydown', (e) => {
            const items = dropdown.querySelectorAll('.search-suggestion-item, .search-view-all');
            if (e.key === 'ArrowDown') {
                e.preventDefault();
                if (dropdown.style.display === 'none') {
                    renderSuggestions(input.value);
                    return;
                }
                if (items.length > 0) {
                    selectedIndex = (selectedIndex + 1) % items.length;
                    updateItemHighlight(items);
                }
            } else if (e.key === 'ArrowUp') {
                e.preventDefault();
                if (items.length > 0) {
                    selectedIndex = (selectedIndex - 1 + items.length) % items.length;
                    updateItemHighlight(items);
                }
            } else if (e.key === 'Enter') {
                e.preventDefault();
                if (dropdown.style.display !== 'none' && selectedIndex >= 0 && items[selectedIndex]) {
                    items[selectedIndex].click();
                } else {
                    executeSearch(input.value);
                }
            } else if (e.key === 'Escape') {
                hideDropdown();
            }
        });

        function updateItemHighlight(items) {
            items.forEach((it, idx) => {
                if (idx === selectedIndex) {
                    it.classList.add('active');
                    it.scrollIntoView({ block: 'nearest' });
                } else {
                    it.classList.remove('active');
                }
            });
        }

        // Submit form on Enter key or button click
        form.addEventListener('submit', (e) => {
            e.preventDefault();
            executeSearch(input.value);
        });

        // Close dropdown when clicking outside
        document.addEventListener('click', (e) => {
            if (!form.contains(e.target)) {
                hideDropdown();
            }
        });
    });
}

window.addEventListener('DOMContentLoaded', initSearch);
