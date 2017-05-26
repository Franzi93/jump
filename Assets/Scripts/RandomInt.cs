using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInt  {

    int start;
    int end;

    public RandomInt(int _start, int _end) {
        start = _start;
        end = _end;
    }
	
	public int random () {
        return Random.Range(start, end);
	}
}
