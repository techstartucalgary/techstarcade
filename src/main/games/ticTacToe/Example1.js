class Example1 extends Phaser.Scene {
    constructor(){
        super({key:"Example1"});
    }

    preload(){
        this.load.image('GFS','assets/TechStart.jpeg');
    }

    create(){
        this.image = this.add.image(400,300,'GFS');

        this.input.keyboard.on('keyup-D', function(event){
            this.image.x += 10;

        },this)

        this.input.keyboard.addKey(Phaser.Input.Keyboard.KeyCodes.A);

        this.input.on('pointerdown',function(event){
            this.image.x = event.x;
            this.image.y = event.y;
        }, this);


        this.input.keyboard.on('keyup-p', function(event){

            var physicsImage= this.physics.add.image(this.image.x, this.image.y, "GFS");
            physicsImage.setVelocity(Phaser.Math.RND.integerInRange(-100,100), -300)
        },this);
    }

 

    // update(delta){
    //     if(this,key_A.isDown)
    //         this.image.x--;
    // }
}