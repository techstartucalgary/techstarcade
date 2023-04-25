import Phaser from './lib/phaser.js'

import Game from './scenes/Game.js'
import GameOver from './scenes/GameOver.js'
import Title from './scenes/Title.js'

var game = new Phaser.Game({
	type: Phaser.AUTO,
	width: 480,
	height: 640,
	scene: [Title,Game, GameOver],
	physics: {
		default: 'arcade',
		arcade: {
			gravity: {
				y: 200
			},
			debug: false
		}
	}
});

function resize() {
	let canvas = document.querySelector('canvas');
	let width = window.innerWidth;
	let height = window.innerHeight;
	let wratio = width / height;
	let ratio = game.config.width / game.config.height;
	if (wratio < ratio) {
		canvas.style.width = width + 'px';
		canvas.style.height = width  + 'px';
	} else {
		canvas.style.width = height  + 'px';
		canvas.style.height = height  + 'px';
	}
}

window.onload = () => {
	resize();
	window.addEventListener('resize', resize, false);
};

