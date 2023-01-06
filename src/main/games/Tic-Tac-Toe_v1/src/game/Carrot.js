import Phaser from '../lib/phaser.js'
export default class Carrot extends Phaser.Physics.Arcade.Sprite {
    /**
    * @param {Phaser.Scene} scene
    * @param {number} x
    * @param {number} y
    * @param {string} texture
    */
    constructor(scene, x, y, texture) {
        super(scene, x, y, texture)

        this.setScale(0.5)
    }
}