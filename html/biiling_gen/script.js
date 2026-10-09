// 1. Initialize product database using a JavaScript Map
const productMap = new Map([
    ["Apple", { price: 120, unit: "kg" }],
    ["Banana", { price: 40, unit: "dozen" }],
    ["Milk", { price: 60, unit: "litre" }],
    ["Bread", { price: 45, unit: "packet" }],
    ["Eggs", { price: 70, unit: "tray" }],
    ["Orange Juice", { price: 95, unit: "bottle" }],
    ["Butter", { price: 55, unit: "pack" }],
    ["Cheese", { price: 110, unit: "block" }],
    ["Tomato", { price: 30, unit: "kg" }],
    ["Potato", { price: 25, unit: "kg" }]
]);

// 2. Select HTML elements
const searchInput = document.getElementById("searchInput");
const productList = document.getElementById("productList");
const cartItems = document.getElementById("cartItems");
const cartTotal = document.getElementById("cartTotal");
const cartCount = document.getElementById("cartCount");
const printBtn = document.getElementById("printBtn");
const clearCartBtn = document.getElementById("clearCartBtn");

// 3. Cart State using a Map
const cart = new Map();

// 4. Cart Operations
function addToCart(name) {
    const details = productMap.get(name);
    if (!details) return;

    if (cart.has(name)) {
        cart.get(name).quantity += 1;
    } else {
        cart.set(name, {
            price: details.price,
            unit: details.unit,
            quantity: 1
        });
    }

    renderCart();
}

function updateQuantity(name, delta) {
    if (!cart.has(name)) return;

    const item = cart.get(name);
    item.quantity += delta;

    if (item.quantity <= 0) {
        cart.delete(name);
    }

    renderCart();
}

function removeFromCart(name) {
    cart.delete(name);
    renderCart();
}

function clearCart() {
    if (cart.size === 0) {
        alert("Cart is already empty!");
        return;
    }

    if (confirm("Are you sure you want to clear all items from the cart?")) {
        cart.clear();
        renderCart();
    }
}

function printBill() {
    if (cart.size === 0) {
        alert("Cart is empty! Please add items before printing the bill.");
        return;
    }

    window.print();
}

function renderCart() {
    cartItems.innerHTML = "";

    if (cart.size === 0) {
        cartItems.innerHTML = `<div class="empty-cart-message">No items in cart. Search and select items to add.</div>`;
        cartTotal.textContent = "₹0";
        cartCount.textContent = "0 items";
        return;
    }

    let grandTotal = 0;
    let totalItems = 0;

    for (const [name, item] of cart) {
        const itemTotal = item.price * item.quantity;
        grandTotal += itemTotal;
        totalItems += item.quantity;

        const cartItemEl = document.createElement("div");
        cartItemEl.className = "cart-item";
        cartItemEl.innerHTML = `
            <div class="cart-item-info">
                <div class="cart-item-name">${name}</div>
                <div class="cart-item-rate">₹${item.price} / ${item.unit}</div>
            </div>
            <div class="cart-item-controls">
                <button class="qty-btn" data-action="decrease" data-name="${name}">-</button>
                <span class="cart-item-qty">${item.quantity}</span>
                <button class="qty-btn" data-action="increase" data-name="${name}">+</button>
            </div>
            <div class="cart-item-total">₹${itemTotal}</div>
            <button class="remove-btn" data-action="remove" data-name="${name}" title="Remove item">&times;</button>
        `;

        cartItems.appendChild(cartItemEl);
    }

    cartTotal.textContent = `₹${grandTotal}`;
    cartCount.textContent = `${totalItems} item${totalItems > 1 ? "s" : ""}`;
}

// Delegate quantity & remove button clicks in cart
cartItems.addEventListener("click", function (event) {
    const target = event.target;
    const action = target.dataset.action;
    const name = target.dataset.name;

    if (!action || !name) return;

    if (action === "increase") {
        updateQuantity(name, 1);
    } else if (action === "decrease") {
        updateQuantity(name, -1);
    } else if (action === "remove") {
        removeFromCart(name);
    }
});

// Clear cart & Print bill button events
if (clearCartBtn) {
    clearCartBtn.addEventListener("click", clearCart);
}

if (printBtn) {
    printBtn.addEventListener("click", printBill);
}

// 5. Listen for user input in search bar
searchInput.addEventListener("input", function () {
    const query = this.value.trim().toLowerCase();

    // Clear previous suggestions
    productList.innerHTML = "";

    // Hide if query is empty
    if (query === "") {
        return;
    }

    let matchCount = 0;

    // Search within the Map
    for (const [name, details] of productMap) {
        if (name.toLowerCase().includes(query)) {
            matchCount++;

            const li = document.createElement("li");
            li.innerHTML = `
                <span>${name}</span>
                <span class="product-price">₹${details.price} / ${details.unit}</span>
            `;

            // When a suggestion item is clicked, add to cart
            li.addEventListener("click", function () {
                addToCart(name);
                searchInput.value = "";
                productList.innerHTML = "";
                searchInput.focus();
            });

            productList.appendChild(li);
        }
    }

    // Show a message if no products match
    if (matchCount === 0) {
        const noMatch = document.createElement("li");
        noMatch.textContent = "No products found";
        noMatch.style.color = "#888";
        noMatch.style.cursor = "default";
        productList.appendChild(noMatch);
    }
});

// Close suggestions dropdown when clicking outside
document.addEventListener("click", function (event) {
    if (!event.target.closest(".search-container")) {
        productList.innerHTML = "";
    }
});
