using System.Linq;
using Godot;

public class MainScene : Node2D
{
    private ParallaxBackground background;

    public override void _Ready()
    {
        background = (ParallaxBackground)GetNode("CanvasLayer/Background");
        AdjustBackgroundScale();
    }

    private void AdjustBackgroundScale()
    {
        var resolution = GetViewport().Size;
        var backgroundTextures = background.GetChildren().Cast<ParallaxLayer>()
            .Select(i => ((Sprite)i.GetChild(0)).Texture).ToList();
        var maxBackgroundYResolution = backgroundTextures.Select(i => i.GetHeight()).Max();
        var maxBackgroundXResolution = backgroundTextures.Select(i => i.GetWidth()).Max();

        var scaleFactor = resolution.y / maxBackgroundYResolution;
        if (scaleFactor * maxBackgroundXResolution < resolution.x)
            scaleFactor *= resolution.x / (scaleFactor * maxBackgroundXResolution);
        foreach (Node child in background.GetChildren())
            if (child is ParallaxLayer parallaxLayer)
                foreach (Node parallaxLayerChild in parallaxLayer.GetChildren())
                    if (parallaxLayerChild is Sprite sprite)
                    {
                        parallaxLayer.MotionMirroring = new Vector2(sprite.Texture.GetWidth() * scaleFactor, 1);
                        var newScale = new Vector2(scaleFactor, scaleFactor);
                        sprite.Scale = newScale;
                        GD.Print($"New scale is {scaleFactor * sprite.Texture.GetWidth()}");
                    }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}