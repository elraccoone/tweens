using ElRaccoone.Tweens.Core;
using UnityEngine;

namespace ElRaccoone.Tweens {
  public static class TextMeshColorTween {
    public static Tween<Color> TweenTextMeshColor (this Component self, Color to, float duration) =>
      Tween<Color>.Add<Driver> (self).Finalize (to, duration);

    public static Tween<Color> TweenTextMeshColor (this GameObject self, Color to, float duration) =>
      Tween<Color>.Add<Driver> (self).Finalize (to, duration);

    private class Driver : Tween<Color, TextMesh> {
      public override Color OnGetFrom () {
        return this.component.color;
      }

      public override void OnUpdate (float easedTime) {
        this.valueCurrent.r = this.InterpolateValue (this.valueFrom.r, this.valueTo.r, easedTime);
        this.valueCurrent.g = this.InterpolateValue (this.valueFrom.g, this.valueTo.g, easedTime);
        this.valueCurrent.b = this.InterpolateValue (this.valueFrom.b, this.valueTo.b, easedTime);
        this.valueCurrent.a = this.InterpolateValue (this.valueFrom.a, this.valueTo.a, easedTime);
        this.component.color = this.valueCurrent;
      }
    }
  }
}