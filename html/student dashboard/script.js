const openBtn = document.getElementById("openBtn");
const doneBtn = document.getElementById("doneBtn");
const viewBtn = document.getElementById("viewBtn");
const popupModal = document.getElementById("popupModal");
const studentContainer = document.getElementById("studentContainer");

// View Details Modal elements
const viewDetailsModal = document.getElementById("viewDetailsModal");
const viewStudentContent = document.getElementById("viewStudentContent");
const closeViewBtn = document.getElementById("closeViewBtn");

// Storage: Array for ordered listing and Map for quick key lookup
const students = [];
const studentsMap = new Map();

// Function to render students as ribbons inside the container
function renderStudents() {
    studentContainer.innerHTML = "";

    if (students.length === 0) {
        studentContainer.innerHTML = '<p class="empty-text">No students added yet. Click "add" to create one.</p>';
        return;
    }

    students.forEach((student, index) => {
        const ribbon = document.createElement("div");
        ribbon.className = "student-ribbon";
        ribbon.innerHTML = `
            <div class="ribbon-badge">#${index + 1}</div>
            <div class="ribbon-details">
                <span class="ribbon-name">${student.name}</span>
                <span class="ribbon-email">${student.email}</span>
            </div>
            <div class="ribbon-actions">
                <button class="btn btn-outline-primary btn-sm view-item-btn" data-email="${student.email}">View</button>
                <button class="btn btn-outline-danger btn-sm delete-item-btn" data-email="${student.email}">Delete</button>
            </div>
        `;
        studentContainer.appendChild(ribbon);
    });
}

// Function to show individual student details in popup
function showStudentDetails(student) {
    viewStudentContent.innerHTML = `
        <p><strong>Name:</strong> ${student.name}</p>
        <p><strong>Email:</strong> ${student.email}</p>
        <p><strong>Phone:</strong> ${student.phn || "N/A"}</p>
        <p><strong>Address:</strong> ${student.addr || "N/A"}</p>
    `;
    viewDetailsModal.classList.add("active");
}

// Handle clicks inside the student container (View and Delete buttons)
studentContainer.addEventListener("click", (e) => {
    const targetViewBtn = e.target.closest(".view-item-btn");
    const targetDeleteBtn = e.target.closest(".delete-item-btn");

    // 1. View button clicked: retrieve details from the Map
    if (targetViewBtn) {
        const email = targetViewBtn.dataset.email;
        const student = studentsMap.get(email);
        if (student) {
            showStudentDetails(student);
        }
    }

    // 2. Delete button clicked: delete from Map & Array, then re-render
    if (targetDeleteBtn) {
        const email = targetDeleteBtn.dataset.email;

        // Delete from Map
        studentsMap.delete(email);

        // Delete from Array
        const index = students.findIndex((s) => s.email === email);
        if (index !== -1) {
            students.splice(index, 1);
        }

        // Re-render ribbons
        renderStudents();
    }
});

// Show the add popup when clicking "add"
openBtn.addEventListener("click", () => {
    popupModal.classList.add("active");
});

// Add student on "Done" click
doneBtn.addEventListener("click", () => {
    const name = document.getElementById("name").value.trim();
    const email = document.getElementById("email").value.trim();
    const phn = document.getElementById("phn").value.trim();
    const addr = document.getElementById("addr").value.trim();

    // Validation
    if (!name || !email) {
        alert("Please enter at least Name and Email!");
        return;
    }

    if (studentsMap.has(email)) {
        alert("A student with this email already exists!");
        return;
    }

    // Fresh student object
    const newStudent = {
        name: name,
        email: email,
        phn: phn,
        addr: addr
    };

    // Store in Array and Map
    students.push(newStudent);
    studentsMap.set(email, newStudent);

    // Re-render ribbons
    renderStudents();

    // Reset and close
    document.getElementById("details").reset();
    popupModal.classList.remove("active");
});

// View button in top nav/buttons
if (viewBtn) {
    viewBtn.addEventListener("click", () => {
        renderStudents();
        studentContainer.scrollIntoView({ behavior: "smooth" });
    });
}

// Close Add popup
popupModal.addEventListener("click", (e) => {
    if (e.target === popupModal) {
        popupModal.classList.remove("active");
    }
});

// Close Details popup
closeViewBtn.addEventListener("click", () => {
    viewDetailsModal.classList.remove("active");
});

viewDetailsModal.addEventListener("click", (e) => {
    if (e.target === viewDetailsModal) {
        viewDetailsModal.classList.remove("active");
    }
});

// Initial render
renderStudents();
