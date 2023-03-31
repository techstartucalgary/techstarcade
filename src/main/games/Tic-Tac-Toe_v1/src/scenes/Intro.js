import Phaser from '../lib/phaser.js'

export default class Start extends Phaser.Scene
{

constructor()
{
    super({
        key: 'Intro'
    });
}


preload(){

    this.load.audio('intro_music', ['assets/audio/01-Opening.ogg']);
		this.load.image('background', 'assets/sprites/titlescreen/background.png');
		this.load.image('bgbox', 'assets/sprites/titlescreen/bgbox.png');
		this.load.image('title', 'assets/sprites/titlescreen/title.png');
		this.load.image(
			'tictactoe',
			'assets/sprites/titlescreen/tictactoetitle.png'
		);

        this.load.image(
			'championships',
			'assets/sprites/titlescreen/championshipstitle.png'
		);
		this.load.image(
			'startbutton',
			'assets/sprites/titlescreen/startbutton.png'
		);
		this.load.audio('coin_sound', ['assets/audio/sfx_coin_double1.wav']);
		this.load.audio('winning_sound', ['assets/audio/sfx_sounds_powerup4.wav']);
		this.load.image('title', 'assets/sprites/titlescreen/title.png');

		this.load.image('box_blank', 'assets/sprites/box_blank.png');
		this.load.image('box_xblue', 'assets/sprites/box_xblue.png');
		this.load.image('box_ored', 'assets/sprites/box_ored.png');
		this.load.image('boardbg', 'assets/sprites/board/boardbg.png');

		this.load.image('playagain', 'assets/sprites/board/playagain.png');
		this.load.image('wins', 'assets/sprites/board/wins.png');

		this.load.image('xIcon', 'assets/sprites/board/x.png');
		this.load.image('oIcon', 'assets/sprites/board/o.png');

		var progress = this.add.graphics();
		const self = this;
		this.load.on('progress', function(value) {
			progress.clear();
			progress.fillStyle(0x42f456, 1);
			progress.fillRect(0, 300, 800 * value, 20);
		});

		this.load.on('complete', function() {
			progress.destroy();
		});
}


create(){
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
    this.bgbox = this.add
			.image(0, 0, 'bgbox')
			.setOrigin(0, 0)
			.setAlpha(0);
    this.title = this.add
			.image(this.game.config.width / 2, 110, 'title')
			.setAlpha(0);

	this.championships = this.add
			.image(this.game.config.width / 2, 200, 'championships')
			.setAlpha(0);

	this.tictactoe = this.add
			.image(this.game.config.width / 2, 220, 'tictactoe')
			.setAlpha(0);

	this.startbutton = this.add
			.image(this.game.config.width / 2, 270, 'startbutton')
			.setAlpha(0);

		/*==============================================
		= Animate GameObjects
		================================================
		*/
		this.bgboxTween = this.tweens.timeline({
			targets: this.bgbox,
			ease: 'Linear',
			loop: 0,
			tweens: [
				{
					alpha: 0.5,
					ease: 'Linear',
					duration: 2000,
					delay: 1000,
					repeat: 0
				}
			]
		});
		this.titleTween = this.tweens.timeline({
			targets: this.title,
			ease: 'Linear',
			loop: 0,
			tweens: [
				{
					y: 100,
					alpha: 1,
					ease: 'Linear',
					duration: 1000,
					delay: 0,
					repeat: 0
				},
				{
					y: 110,
					alpha: 1,
					ease: 'Linear',
					duration: 600,
					delay: 0,
					repeat: -1,
					yoyo: true
				}
			]
		});
		this.championshipTween = this.tweens.timeline({
			targets: this.championships,
			ease: 'Linear',
			loop: 0,
			tweens: [
				{
					y: 170,
					alpha: 1,
					ease: 'Linear',
					duration: 600,
					delay: 1000,
					repeat: 0
				}
			]
		});
		this.tictactoeTween = this.tweens.timeline({
			targets: this.tictactoe,
			ease: 'Linear',
			loop: 0,
			tweens: [
				{
					y: 200,
					alpha: 1,
					ease: 'Linear',
					duration: 600,
					delay: 1300,
					repeat: 0
				}
			]
		});
		this.startbuttonTween = this.tweens.timeline({
			targets: this.startbutton,
			ease: 'Linear',
			loop: 0,
			tweens: [
				{
					y: 240,
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

		this.startbutton.setInteractive().on('pointerdown', () => {
			this.intro_music.stop();
			this.scene.start('Level1');
		});
	}
	update(delta) {
		if (this.keys.SPACE.isDown || this.keys.ENTER.isDown) {
			this.scene.start('Level1');
		}
	}


}


