using UnityEngine;

public class ColorSpeed : MonoBehaviour
{
    public CarMovement carMovement; // Reference to the CarMovement script
    public Renderer carRenderer; // Reference to the car's Renderer component

    // Enum to define different colors
    public enum CarColor
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Purple
    }

    // Define the colors and their associated speeds
    [System.Serializable]
    public struct ColorSpeedPair
    {
        public CarColor color;
        public Color colorValue;
        public float maxSpeed;
        
    }

    // Define colors and their speed multipliers
    public ColorSpeedPair[] colorSpeedPairs = new ColorSpeedPair[]
    {
        new ColorSpeedPair { color = CarColor.Red, colorValue = Color.red, maxSpeed = 80f },
        new ColorSpeedPair { color = CarColor.Orange, colorValue = new Color(1f, 0.5f, 0f), maxSpeed = 76f },
        new ColorSpeedPair { color = CarColor.Yellow, colorValue = Color.yellow, maxSpeed = 72f },
        new ColorSpeedPair { color = CarColor.Green, colorValue = Color.green, maxSpeed = 68f }, 
        new ColorSpeedPair { color = CarColor.Blue, colorValue = Color.blue, maxSpeed = 64f },
        new ColorSpeedPair { color = CarColor.Purple, colorValue = new Color(0.5f, 0f, 0.5f), maxSpeed = 60f }
    };

    private int currentColorIndex = 0;

    void Start()
    {
        // Initialize the car's color and speed
        UpdateCarColor();
    }

    void Update()
    {
        // Check for input to change the car color and speed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Cycle to the next color
            currentColorIndex = (currentColorIndex + 1) % colorSpeedPairs.Length;
            UpdateCarColor();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            // Cycle to the previous color
            currentColorIndex = (currentColorIndex - 1 + colorSpeedPairs.Length) % colorSpeedPairs.Length;
            UpdateCarColor();
        }
    }

    void UpdateCarColor()
    {
        // Set the car's color based on the current color index
        carRenderer.material.color = colorSpeedPairs[currentColorIndex].colorValue;

        // Update the car's speed based on the current color
        float speedMultiplier = colorSpeedPairs[currentColorIndex].maxSpeed;
        carMovement.SetMaxSpeedMultiplier(speedMultiplier);
       
        
    }
}
