export default class Level1 extends Phaser.Scene {
	constructor() {
		super({
			key: 'Level1'
		});
	}
	preload() {}
	create() {
		this.gameBoard = [0, 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i'];

		this.currentPlayer = true;
		/*==============================================
		= Music 
		================================================
		*/
		this.intro_music = this.sound.add('intro_music', {
			mute: false,
			volume: 1,
			rate: 1,
			detune: 0,
			seek: 0,
			loop: true,
			delay: 0
		});
		this.intro_music.play();
		this.coin_sound = this.sound.add('coin_sound');
		this.winning_sound = this.sound.add('winning_sound');
		/*==============================================
		= GameObjects
		================================================
		*/
		this.background = this.add.image(0, 0, 'background').setOrigin(0, 0);

		this.title = this.add
			.image(this.game.config.width / 2, 50, 'title')
			.setScale(0.5, 0.5);

		// GAMEBOARD DISPLAY GameObjects
		this.boardbg = this.add.image(21, 91, 'boardbg').setOrigin(0, 0);

		this.box_blank1 = this.add
			.image(32, 102, 'box_blank')
			.setOrigin(0, 0)
			.setInteractive()
			.setDataEnabled()
			.data.set('box_number', 1);

		this.box_blank2 = this.add
			.image(74, 102, 'box_blank')
			.setOrigin(0, 0)
			.setInteractive()
			.setDataEnabled()
			.data.set('box_number', 2);

		this.box_blank3 = this.add
			.image(116, 102, 'box_blank')
			.setOrigin(0, 0)
			.setInteractive()
			.setDataEnabled()
			.data.set('box_number', 3);

		this.box_blank4 = this.add
			.image(32, 144, 'box_blank')
			.setOrigin(0, 0)
			.setInteractive()
			.setDataEnabled()
			.data.set('box_number', 4);

		this.box_blank5 = this.add
			.image(74, 144, 'box_blank')
			.setOrigin(0, 0)
			.setInteractive()
			.setDataEnabled()
			.data.set('box_number', 5);

		this.box_blank6 = this.add
			.image(116, 144, 'box_blank')
			.setOrigin(0, 0)
			.setInteractive()
			.setDataEnabled()
			.data.set('box_number', 6);

		this.box_blank7 = this.add
			.image(32, 186, 'box_blank')
			.setOrigin(0, 0)
			.setInteractive()
			.setDataEnabled()
			.data.set('box_number', 7);

		this.box_blank8 = this.add
			.image(74, 186, 'box_blank')
			.setOrigin(0, 0)
			.setInteractive()
			.setDataEnabled()
			.data.set('box_number', 8);

		this.box_blank9 = this.add
			.image(116, 186, 'box_blank')
			.setOrigin(0, 0)
			.setInteractive()
			.setDataEnabled()
			.data.set('box_number', 9);

		// DISPLAY WINNING GameObjects
		this.playagainBtn = this.add
			.image(this.game.config.width / 2, 400, 'playagain')
			.setDepth(5)
			.setInteractive();
		this.playagainBtn.on('pointerdown', (pointer, localX, localY, event) => {
			this.intro_music.stop();
			// this.scene.stop();
			// this.scene.start('Level1');
			this.scene.restart();
		});
		this.wins = this.add.image(-200, 150, 'wins').setDepth(5);
		this.xIcon = this.add
			.image(this.game.config.width / 2 - 0, 140, 'xIcon')
			.setAlpha(0)
			.setScale(0.5, 0.5)
			.setDepth(6);

		this.draw = this.add
			.image(this.game.config.width / 2 - 0, 140, 'draw')
			.setAlpha(0)
			.setScale(0.5, 0.5)
			.setDepth(6);

		this.oIcon = this.add
			.image(this.game.config.width / 2 - 10, 140, 'oIcon')
			.setAlpha(0)
			.setScale(0.5, 0.5)
			.setDepth(6);

		this.clickedBox();
	}
	clickedBox() {
		let player = this.currentPlayer ? 'x' : 'o';

		this.input.on('gameobjectdown', (pointer, gameObject) => {
			if (this.gameBoard[1] == 'a' && gameObject.data.get('box_number') == 1) {
				gameObject.destroy();
				this.box_blank1 = this.add
					.image(
						gameObject.x,
						gameObject.y,
						this.currentPlayer ? 'box_xblue' : 'box_ored'
					)
					.setOrigin(0, 0);
				this.gameBoard[1] = this.currentPlayer ? 'x' : 'o';
				this.checkWin();
				this.currentPlayer = !this.currentPlayer;
				this.coin_sound.play();
			} else if (
				this.gameBoard[2] == 'b' &&
				gameObject.data.get('box_number') == 2
			) {
				gameObject.destroy();
				this.box_blank1 = this.add
					.image(
						gameObject.x,
						gameObject.y,
						this.currentPlayer ? 'box_xblue' : 'box_ored'
					)
					.setOrigin(0, 0);
				this.gameBoard[2] = this.currentPlayer ? 'x' : 'o';
				this.checkWin();
				this.currentPlayer = !this.currentPlayer;
				this.coin_sound.play();
			} else if (
				this.gameBoard[3] == 'c' &&
				gameObject.data.get('box_number') == 3
			) {
				gameObject.destroy();
				this.box_blank1 = this.add
					.image(
						gameObject.x,
						gameObject.y,
						this.currentPlayer ? 'box_xblue' : 'box_ored'
					)
					.setOrigin(0, 0);
				this.gameBoard[3] = this.currentPlayer ? 'x' : 'o';
				this.checkWin();
				this.currentPlayer = !this.currentPlayer;
				this.coin_sound.play();
			} else if (
				this.gameBoard[4] == 'd' &&
				gameObject.data.get('box_number') == 4
			) {
				gameObject.destroy();
				this.box_blank1 = this.add
					.image(
						gameObject.x,
						gameObject.y,
						this.currentPlayer ? 'box_xblue' : 'box_ored'
					)
					.setOrigin(0, 0);
				this.gameBoard[4] = this.currentPlayer ? 'x' : 'o';
				this.checkWin();
				this.currentPlayer = !this.currentPlayer;
				this.coin_sound.play();
			} else if (
				this.gameBoard[5] == 'e' &&
				gameObject.data.get('box_number') == 5
			) {
				gameObject.destroy();
				this.box_blank1 = this.add
					.image(
						gameObject.x,
						gameObject.y,
						this.currentPlayer ? 'box_xblue' : 'box_ored'
					)
					.setOrigin(0, 0);
				this.gameBoard[5] = this.currentPlayer ? 'x' : 'o';
				this.checkWin();
				this.currentPlayer = !this.currentPlayer;
				this.coin_sound.play();
			} else if (
				this.gameBoard[6] == 'f' &&
				gameObject.data.get('box_number') == 6
			) {
				gameObject.destroy();
				this.box_blank1 = this.add
					.image(
						gameObject.x,
						gameObject.y,
						this.currentPlayer ? 'box_xblue' : 'box_ored'
					)
					.setOrigin(0, 0);
				this.gameBoard[6] = this.currentPlayer ? 'x' : 'o';
				this.checkWin();
				this.currentPlayer = !this.currentPlayer;
				this.coin_sound.play();
			} else if (
				this.gameBoard[7] == 'g' &&
				gameObject.data.get('box_number') == 7
			) {
				gameObject.destroy();
				this.box_blank1 = this.add
					.image(
						gameObject.x,
						gameObject.y,
						this.currentPlayer ? 'box_xblue' : 'box_ored'
					)
					.setOrigin(0, 0);
				this.gameBoard[7] = this.currentPlayer ? 'x' : 'o';
				this.checkWin();
				this.currentPlayer = !this.currentPlayer;
				this.coin_sound.play();
			} else if (
				this.gameBoard[8] == 'h' &&
				gameObject.data.get('box_number') == 8
			) {
				gameObject.destroy();
				this.box_blank1 = this.add
					.image(
						gameObject.x,
						gameObject.y,
						this.currentPlayer ? 'box_xblue' : 'box_ored'
					)
					.setOrigin(0, 0);
				this.gameBoard[8] = this.currentPlayer ? 'x' : 'o';
				this.checkWin();
				this.currentPlayer = !this.currentPlayer;
				this.coin_sound.play();
			} else if (
				this.gameBoard[9] == 'i' &&
				gameObject.data.get('box_number') == 9
			) {
				gameObject.destroy();
				this.box_blank1 = this.add
					.image(
						gameObject.x,
						gameObject.y,
						this.currentPlayer ? 'box_xblue' : 'box_ored'
					)
					.setOrigin(0, 0);
				this.gameBoard[9] = this.currentPlayer ? 'x' : 'o';
				this.checkWin();
				this.currentPlayer = !this.currentPlayer;
				this.coin_sound.play();
			} else {
				alert("Can't do that!");
			}
		});
	}
	winningAnimation(winner) {
		this.tweens.add({
			targets: this.wins,
			x: this.game.config.width / 2,
			y: 150,
			ease: 'Linear',
			duration: 500,
			repeat: 0,
			yoyo: false
		});
		if (winner == 'x') {
			this.tweens.add({
				targets: this.xIcon,
				x: this.game.config.width / 2,
				y: 140,
				alpha: 1,
				ease: 'Linear',
				delay: 500,
				duration: 300,
				repeat: 0,
				yoyo: false
			});
			this.winning_sound.play();
		} else if (winner == 'o') {
			this.tweens.add({
				targets: this.oIcon,
				x: this.game.config.width / 2,
				y: 140,
				alpha: 1,
				ease: 'Linear',
				delay: 500,
				duration: 300,
				repeat: 0,
				yoyo: false
			});
			this.winning_sound.play();
		} else {
			alert('draw');
		}
		this.tweens.add({
			targets: this.playagainBtn,
			x: this.game.config.width / 2,
			y: 275,
			alpha: 1,
			ease: 'Linear',
			delay: 1000,
			duration: 300,
			repeat: 0,
			yoyo: false
		});
	}

	drawAnimation() {

	
		this.winning_sound.play();
		
		this.tweens.add({
			targets: this.playagainBtn,
			x: this.game.config.width / 2,
			y: 275,
			alpha: 1,
			ease: 'Linear',
			delay: 1000,
			duration: 300,
			repeat: 0,
			yoyo: false
		});
	}
	checkWin() {
		let player = this.currentPlayer ? 'x' : 'o';

		if (
			this.gameBoard[1] == this.gameBoard[2] &&
			this.gameBoard[2] == this.gameBoard[3]
		) {
			this.winningAnimation(player);
		} else if (
			this.gameBoard[4] == this.gameBoard[5] &&
			this.gameBoard[5] == this.gameBoard[6]
		) {
			this.winningAnimation(player);
		} else if (
			this.gameBoard[7] == this.gameBoard[8] &&
			this.gameBoard[8] == this.gameBoard[9]
		) {
			this.winningAnimation(player);
		} else if (
			this.gameBoard[1] == this.gameBoard[4] &&
			this.gameBoard[4] == this.gameBoard[7]
		) {
			this.winningAnimation(player);
		} else if (
			this.gameBoard[2] == this.gameBoard[5] &&
			this.gameBoard[5] == this.gameBoard[8]
		) {
			this.winningAnimation(player);
		} else if (
			this.gameBoard[3] == this.gameBoard[6] &&
			this.gameBoard[6] == this.gameBoard[9]
		) {
			this.winningAnimation(player);
		} else if (
			this.gameBoard[1] == this.gameBoard[5] &&
			this.gameBoard[5] == this.gameBoard[9]
		) {
			this.winningAnimation(player);
		} else if (
			this.gameBoard[3] == this.gameBoard[5] &&
			this.gameBoard[5] == this.gameBoard[7]
		) {
			this.winningAnimation(player);
		} else if (
			this.gameBoard[1] != 'a' &&
			this.gameBoard[2] != 'b' &&
			this.gameBoard[3] != 'c' &&
			this.gameBoard[4] != 'd' &&
			this.gameBoard[5] != 'e' &&
			this.gameBoard[6] != 'f' &&
			this.gameBoard[7] != 'g' &&
			this.gameBoard[8] != 'h' &&
			this.gameBoard[9] != 'i'
		) {
	
			this.drawAnimation();
		} else {
			console.log('continue');
		}
	}
	update(time, delta) {}
}
