document.addEventListener('DOMContentLoaded', function() {

    // elements
    var b0 = document.getElementById('buttonHome');
    var b1 = document.getElementById('buttonBunny');
    var b2 = document.getElementById('buttonJourney');
    var b3 = document.getElementById('buttonMine');
    var b4 = document.getElementById('buttonRocket');
    var b5 = document.getElementById('buttonSnake');
    var b6 = document.getElementById('buttonInvader');
    var b7 = document.getElementById('buttonTic');

    var c0 = document.getElementById('containerDefault');
    var c1 = document.getElementById('containerBunny');
    var c2 = document.getElementById('containerJourney');
    var c3 = document.getElementById('containerMine');
    var c4 = document.getElementById('containerRocket');
    var c5 = document.getElementById('containerSnake');
    var c6 = document.getElementById('containerInvader');
    var c7 = document.getElementById('containerTic');

    var f1 = document.getElementById('frameBunny');
    var f2 = document.getElementById('frameJourney');
    var f3 = document.getElementById('frameMine');
    var f4 = document.getElementById('frameRocket');
    var f5 = document.getElementById('frameSnake');
    var f6 = document.getElementById('frameInvader');
    var f7 = document.getElementById('frameTic');

    const s1 = f1.src;
    const s2 = f2.src;
    const s3 = f3.src;
    const s4 = f4.src;
    const s5 = f5.src;
    const s6 = f6.src;
    const s7 = f7.src;

    var cActive = c0;
    var fActive = f1;

    //start on empty screen
    reset();
    c0.style.display = "block";

    //buttons display each game
    b0.addEventListener('click', function() {
        changeFocus();
        c0.style.display = "block";
        cActive = c0;
        fActive = f1;
    }, false);

    b1.addEventListener('click', function() {
        changeFocus();
        c1.style.display = "block";
        cActive = c1;
        fActive = f1;
        fActive.src = s1;
    }, false);

    b2.addEventListener('click', function() {
        changeFocus();
        c2.style.display = "block";
        cActive = c2;
        fActive = f2;
        fActive.src = s2;
    }, false);
    
    b3.addEventListener('click', function() {
        changeFocus();
        c3.style.display = "block";
        cActive = c3;
        fActive = f3;
        fActive.src = s3;
    }, false);

    b4.addEventListener('click', function() {
        changeFocus();
        c4.style.display = "block";
        cActive = c4;
        fActive = f4;
        fActive.src = s4;
    }, false);    
    
    b5.addEventListener('click', function() {
        changeFocus();
        c5.style.display = "block";
        cActive = c5;
        fActive = f5;
        fActive.src = s5;
    }, false);    
    
    b6.addEventListener('click', function() {
        changeFocus();
        c6.style.display = "block";
        cActive = c6;
        fActive = f6;
        fActive.src = s6;
    }, false);    
    
    b7.addEventListener('click', function() {
        changeFocus();
        c7.style.display = "block";
        cActive = c7;
        fActive = f7;
        fActive.src = s7;
    }, false);
    
    //used to reset content
    function reset() {
        c0.style.display = "none";
        c1.style.display = "none";
        c2.style.display = "none";
        c3.style.display = "none";
        c4.style.display = "none";
        c5.style.display = "none";
        c6.style.display = "none";
        c7.style.display = "none";

        f1.src = '';
        f2.src = '';
        f3.src = '';
        f4.src = '';
        f5.src = '';
        f6.src = '';
        f7.src = '';
    };

    function changeFocus() {
        //reloads and hides previous game
        fActive.src = '';
        cActive.style.display = "none";
    };

}, false);