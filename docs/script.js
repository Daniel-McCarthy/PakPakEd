var scale = 4;
var objectTypeSelection = 3;
var directionSelection = 2;

var width = 28; //Level is 84 pixels, a block is 3 pixels. This is 84/3
var levelPieces = Array(width*width).fill(0); //84x84 level size, this is one element per block

var timerValue = 45;

function fillCanvas()
{
	var canvas = document.getElementById("editorCanvas");
	var context = canvas.getContext("2d");

	context.fillStyle = "blue";
	context.fillRect(0, 0, 84*4, 84*4);

}

function setObjectType(typeID)
{
	objectTypeSelection = typeID;
	updateSelectionDisplay();
}

function setDirectionSelection(directionID)
{
	directionSelection = directionID;
	updateSelectionDisplay();
}

function updateTimerValue(newValue)
{
	//Set new timer value
	timerValue = newValue;

	//Write new slider label
	document.getElementById("timerLabel").innerHTML = "Timer Length: " + timerValue.toString() + " Seconds";

	//Redraw player spawn points
    for (var i = 0; i < levelPieces.length; i++)
	{
		if(levelPieces[i] == 8)
		{
			var xPos = i % 28;
			var yPos = Math.floor(i / 28);

			drawPieceToCanvas(xPos, yPos, 8);
		}
	}
	
	//Redraw Final Image
	drawFinalImage();
}

function drawBlock(event)
{
	var canvas = document.getElementById("editorCanvas");
	var canvasRect = canvas.getBoundingClientRect();
    var mouseX = event.clientX - canvasRect.left;
    var mouseY = event.clientY - canvasRect.top;
	
	var levelPieceXPos = Math.floor(mouseX / (3 * scale));
	var levelPieceYPos = Math.floor(mouseY / (3 * scale));
	
	var levelPiece = objectTypeSelection;
	
	
	if(levelPiece == 3) //If enemy object is selected
            {
                if (directionSelection == 0) //if up is selected, set to up enemy
                {
                    levelPiece = 4;
                }

                if(directionSelection == 1) //if down is selected, set to down enemy
                {
                    levelPiece = 5;
                }

                if(directionSelection == 3) //if left is selected, set to left enemy
                {
                    levelPiece = 6;
                }

                if(directionSelection == 4) //if right is selected, set to right enemy
                {
                    levelPiece = 7;
                }

                //if center is selected, it will default to 3.
            }

            if (levelPiece == 9) //If object directional pad is selected
            {
                if(directionSelection == 1) //If direction is down, set to down directional pad
                {
                    levelPiece = 10; 
                }

                if(directionSelection == 3) //If direction is left, set to left directional pad
                {
                    levelPiece = 11;
                }

                if(directionSelection == 4) //If direction is right, set to right directional pad
                {
                    levelPiece = 12;
                }

                //If direction is up it stays 9, if it is central direction it stays 9 because there is no center pad
            }

            drawPieceToCanvas(levelPieceXPos, levelPieceYPos, levelPiece);
			editLevelPiece(levelPieceXPos, levelPieceYPos, levelPiece);
			drawFinalImage();

}

function editLevelPiece(x, y, newPieceID)
{
	if(x < 28 && y < 28 && newPieceID <= 12)
	{
		var arrayPos = x + (y * width);
		levelPieces[arrayPos] = newPieceID;
	}
}

function drawFinalImage()
{
	var editorCanvas = document.getElementById("editorCanvas");
	var editorCanvasContext = editorCanvas.getContext("2d");
	var finalImageCanvasContext = document.getElementById("finalImageCanvas").getContext("2d");
	
	finalImageCanvasContext.drawImage(editorCanvas, 0,0, editorCanvas.width, editorCanvas.height,
		0, 0, Math.floor(editorCanvas.width/scale), Math.floor(editorCanvas.height/scale));
}

function drawPieceToCanvas(x, y, newPieceID)
{
	if(x < 28 && y < 28)
	{
		var canvas = document.getElementById("editorCanvas");
		var context = canvas.getContext("2d");

		//context.fillStyle = "blue";
		//context.fillRect(0, 0, 84*4, 84*4);
		
		switch(newPieceID)
		{
			case 0: //Wall
			{
				context.fillStyle = "blue";
				context.fillRect((x * 3) * scale, (y*3) * scale, 3 * scale, 3 * scale);
				break;
			}
			case 1: //Path
			{
				context.fillStyle = "black";
				context.fillRect((x * 3) * scale, (y*3) * scale, 3 * scale, 3 * scale);
				break;
			}
			case 2: //Collectible
			{
				context.fillStyle = "lightgreen";
				context.fillRect((x * 3) * scale, (y*3) * scale, 3 * scale, 3 * scale);
				break;
			}
			case 3: //Enemy
			{
				context.fillStyle = "red";
				context.fillRect((x * 3) * scale, (y*3) * scale, 3 * scale, 3 * scale);
				break;
			}
			case 4: //Enemy Up
			{
				//Enemy Box
				context.fillStyle = "red";
				context.fillRect((x * 3) * scale, (y*3) * scale, 3 * scale, 3 * scale);
				
				//Direction Up Box
				context.fillStyle = "rgb(255,128,0)"; //Orange
				context.fillRect( ((x * 3) * scale) + (1 * scale), (y*3) * scale, 1 * scale, 1 * scale);
				break;
			}
			case 5: //Enemy Down
			{
				//Enemy Box
				context.fillStyle = "red";
				context.fillRect((x * 3) * scale, (y*3) * scale, 3 * scale, 3 * scale);
				
				//Direction Down Box
				context.fillStyle = "rgb(255,128,0)"; //Orange
				context.fillRect( ((x * 3) * scale) + (1 * scale), ((y*3) * scale)  + (2 * scale), 1 * scale, 1 * scale);
				break;
			}
			case 6: //Enemy Left
			{
				//Enemy Box
				context.fillStyle = "red";
				context.fillRect((x * 3) * scale, (y*3) * scale, 3 * scale, 3 * scale);
				
				//Direction Left Box
				context.fillStyle = "rgb(255,128,0)"; //Orange
				context.fillRect( (x * 3) * scale, ((y*3) * scale)  + (1 * scale), 1 * scale, 1 * scale);
				break;
			}
			case 7: //Enemy Right
			{
				//Enemy Box
				context.fillStyle = "red";
				context.fillRect((x * 3) * scale, (y*3) * scale, 3 * scale, 3 * scale);
				
				//Direction Right Box
				context.fillStyle = "rgb(255,128,0)"; //Orange
				context.fillRect( ((x * 3) * scale) + (2 * scale), ((y*3) * scale)  + (1 * scale), 1 * scale, 1 * scale);
				break;
			}
			case 8: //Player
			{
				context.fillStyle = "rgb(255, 128," + timerValue.toString() + ")"; //Custom Orange depending on timer value
				context.fillRect((x * 3) * scale, (y*3) * scale, 3 * scale, 3 * scale);
				break;
			}
			case 9: //Directional Up
			{
				context.fillStyle = "rgb(0,150,255)"; //Light blue
				context.fillRect((x * 3) * scale, (y*3) * scale, 3 * scale, 3 * scale);
				
				//Direction Up Box
				context.fillStyle = "rgb(128,150,255)"; //Purple Blue
				context.fillRect( ((x * 3) * scale) + (1 * scale), (y*3) * scale, 1 * scale, 1 * scale);
				break;
			}
			case 10: //Directional Down
			{
				context.fillStyle = "rgb(0,150,255)"; //Light blue
				context.fillRect((x * 3) * scale, (y*3) * scale, 3 * scale, 3 * scale);
				
				//Direction Down Box
				context.fillStyle = "rgb(128,150,255)"; //Purple Blue
				context.fillRect( ((x * 3) * scale) + (1 * scale), ((y*3) * scale) + (2 * scale), 1 * scale, 1 * scale);
				break;
			}
			case 11: //Directional Left
			{
				context.fillStyle = "rgb(0,150,255)"; //Light blue
				context.fillRect((x * 3) * scale, (y*3) * scale, 3 * scale, 3 * scale);
				
				//Direction Down Left
				context.fillStyle = "rgb(128,150,255)"; //Purple Blue
				context.fillRect( ((x * 3) * scale), ((y*3) * scale) + (1 * scale), 1 * scale, 1 * scale);
				break;
			}
			case 12: //Directional Right
			{
				context.fillStyle = "rgb(0,150,255)"; //Light blue
				context.fillRect((x * 3) * scale, (y*3) * scale, 3 * scale, 3 * scale);
				
				//Direction Right Box
				context.fillStyle = "rgb(128,150,255)"; //Purple Blue
				context.fillRect( ((x * 3) * scale) + (2 * scale), ((y*3) * scale) + (1 * scale), 1 * scale, 1 * scale);
				break;
			}
		}
	}
}

function updateSelectionDisplay()
{
	var display = "";

	switch (objectTypeSelection)
	{

		case 0:
			{
				display += "Wall";
				break;
			}
		case 1:
			{
				display += "Path";
				break;
			}
		case 2:
			{
				display += "Collectible";
				break;
			}
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
			{
				display += "Enemy";
				break;
			}
		case 8:
			{
				display += "Player";
				break;
			}
		case 9:
		case 10:
		case 11:
		case 12:
			{
				display += "Directional Pad";
				break;
			}
	}

	if ((objectTypeSelection >= 3 && objectTypeSelection < 8) || objectTypeSelection >= 9)
	{
		switch (directionSelection)
		{
			case 0:
				{
					display += ", Up";
					break;
				}
			case 1:
				{
					display += ", Down";
					break;
				}
			case 3:
				{
					display += ", Left";
					break;
				}
			case 4:
				{
					display += ", Right";
					break;
				}
		}
	}
	
	if (objectTypeSelection == 9 && directionSelection == 2) //If directional pad selected with no direction then display as up
	{
		display += ", Up";
	}

	document.getElementById("blockInfoLabel").innerHTML = display;
}
