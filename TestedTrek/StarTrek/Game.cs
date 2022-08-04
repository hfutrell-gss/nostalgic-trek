using System;
using System.Collections.Generic;
using StarTrek;
using Untouchables;

public class Game {
    private int _energy = 10000;

    public int EnergyRemaining() {
        return _energy;
    }

    public int Torpedoes { set; get; } = 8;

    public void FireWeapon(WebGadget wg) {
        FireWeapon(new Galaxy(wg));
    }

    public void FireWeapon(Galaxy wg)
    {
        var enemy = (Klingon)wg.Variable("target");
        
        if (wg.Parameter("command").Equals("phaser"))
        {
            var phaser = new Phaser();
            _energy -= phaser.FireWeapon(wg, _energy, Rnd);
        } else if (wg.Parameter("command").Equals("photon")) {
            var photon = new Photon();
            Torpedoes -= photon.FireWeapon(wg, Torpedoes, Rnd);
        }
	}


    // note we made generator public in order to mock it
    // it's ugly, but it's telling us something about our *design!* ;-)
	public static Random generator = new Random();
	private static int Rnd(int maximum) {
		return generator.Next(maximum);
	}

}
