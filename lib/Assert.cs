using UnityEngine;
using System.Collections;

public class Assert {

	public static void Test(bool condition,System.Func<string> strf){
		if (!condition) {
			Debug.LogError(strf());
			Debug.Break();
		}
	}

	public static void Test(bool condition){
		if (!condition) {
			Debug.LogError("Assertion failed");
			Debug.Break();
		}
	}
}
