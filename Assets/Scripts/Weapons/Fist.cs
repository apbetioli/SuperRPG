using System;

public class Fist : Weapon {

	public override int Damage() {
		return 1;
	}

	public string Name(){
		return "Fist";
	}

	public override string Texto() {
		return "Your own fists";
	}

}


