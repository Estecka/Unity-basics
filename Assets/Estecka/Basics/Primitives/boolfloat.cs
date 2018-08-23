namespace Estecka {
	/// <summary>
	/// A float implicitely convertible to a bool.
	/// Worth <c>True</c> if different from <c>0</c>.
	/// </summary>
	public struct boolfloat {
		float raw;
		private boolfloat(float raw){ this.raw = raw; }
		public static implicit operator bool (boolfloat i) { return i.raw != 0; }
		public static implicit operator float(boolfloat i) { return i.raw; }
		public static implicit operator boolfloat(float f) { return new boolfloat (f); }
		public static implicit operator boolfloat(bool  b) { return new boolfloat (b?1:0); }
	} // END Struct
} // END Namespace