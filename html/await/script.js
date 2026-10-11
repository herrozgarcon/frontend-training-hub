
async function func() {
    let info = document.getElementById('info');
    let btn = document.getElementById('infobtn');

    // If currently visible, hide it
    if (info.style.display === "block") {
        info.style.display = "none";
        btn.innerText = "Display Info";
    } else {
        // If content is not loaded yet, fetch it
        if (!info.innerText) {
            let response = await fetch('info.txt');
            let text = await response.text();
            info.innerText = text;
        }
        info.style.display = "block"; 
        btn.innerText = "Hide Info";
    }
}

