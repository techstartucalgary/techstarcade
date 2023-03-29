import Phaser from '../lib/phaser.js'

export default class Start extends Phaser.Scene {

	constructor() {

		super('title')

	}


	preload() {

		this.load.audio('intro_music', 'assets/sfx/introMusic.mp3');
		this.load.image('background', 'assets/bg_layer1.png');
		this.load.image('cloud', 'assets/Clouds.png');
		this.load.image('startButton', 'assets/startbutton.png');
	}


	create() {
	
		/*==============================================
		= Audio
		================================================
		*/
		this.intro_music = this.sound.add('intro_music', {
			mute: false,
			volume: 1,
			loop: true
		});
		this.intro_music.play();
		this.background = this.add.image(0, 0, 'background').setOrigin(0, 0);
		this.cloud = this.add.image(0, 0, 'cloud').setOrigin(30, 30);

		this.startButton = this.add
			.image(this.game.config.width / 2, 270, 'startButton')
			.setAlpha(0);
		this.add.text(this.game.config.width / 2, this.game.config.height / 2, 'Bunny Jump', {
			fontSize: 48
		}).setOrigin(0.5)		
		/*==============================================
		= Animate GameObjects
		================================================
		*/
		this.startButtonTween = this.tweens.timeline({
			targets: this.startButton,
			ease: 'Linear',
			loop: 0,
			tweens: [
				{
					y: 500,
					alpha: 1,
					ease: 'Linear',
					duration: 500,
					delay: 1600,
					repeat: 0
				}
			]
		});
		/*==============================================
		= Actions
		================================================
		*/
		this.keys = this.input.keyboard.addKeys('ENTER,SPACE');

		this.startButton.setInteractive().on('pointerdown', () => {
			this.intro_music.stop();
			this.scene.start('game');
		});
	}
	update(delta) {
		if (this.keys.SPACE.isDown || this.keys.ENTER.isDown) {
			this.intro_music.stop();
			this.scene.start('game');
		}
	}


}


