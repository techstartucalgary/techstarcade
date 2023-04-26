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

    //start on empty screen
    reset();
    c0.style.display = "block";

    //buttons display each game
    b0.addEventListener('click', function() {
        reset();
        c0.style.display = "block";
    }, false);

    b1.addEventListener('click', function() {
        reset();
        c1.style.display = "block";
    }, false);

    b2.addEventListener('click', function() {
        reset();
        c2.style.display = "block";
    }, false);
    
    b3.addEventListener('click', function() {
        reset();
        c3.style.display = "block";
    }, false);

    b4.addEventListener('click', function() {
        reset();
        c4.style.display = "block";
    }, false);    
    
    b5.addEventListener('click', function() {
        reset();
        c5.style.display = "block";
    }, false);    
    
    b6.addEventListener('click', function() {
        reset();
        c6.style.display = "block";
    }, false);    
    
    b7.addEventListener('click', function() {
        reset();
        c7.style.display = "block";
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

        //reloads games so none are running in background
        f1.src += '';
        f2.src += '';
        f3.src += '';
        f4.src += '';
        f5.src += '';
        f6.src += '';
        f7.src += '';
    };

}, false);