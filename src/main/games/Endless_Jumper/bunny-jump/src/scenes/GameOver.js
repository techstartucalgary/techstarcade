import Phaser from '../lib/phaser.js'

export default class GameOver extends Phaser.Scene
{
	constructor()
	{
		super('game-over')
	}
	preload() {

		this.load.image('playAgainButton', 'assets/playagain.png');

	}

	create()
	{
		const width = this.scale.width
		const height = this.scale.height

		this.playAgainButton = this.add
		.image(this.game.config.width / 2, 270, 'playAgainButton')
		.setAlpha(0);

		this.add.text(width * 0.5, height * 0.5, 'Game Over', {
			fontSize: 48
		})
		.setOrigin(0.5)

		this.input.keyboard.once('keydown-SPACE', () => {
			this.scene.start('title')
		})

		this.playAgainButtonTween = this.tweens.timeline({
			targets: this.playAgainButton,
			ease: 'Linear',
			loop: 0,
			tweens: [
				{
					y: 500,
					alpha: 1,
					ease: 'Linear',
					duration: 500,
					delay: 200,
					repeat: 0
				}
			]
		});

		this.playAgainButton.setInteractive().on('pointerdown', () => {
			
			this.scene.start('title');
		});
	}
}