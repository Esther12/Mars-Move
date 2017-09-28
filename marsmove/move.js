/**
 * Created by esthersu on 2017-09-26.
 */
function initRover() {
    var RC = document.getElementById('Rolls').value;
    console.log(RC);
    var RandC = RC.split(";");
    var rows = RandC[0];
    var cols = RandC[1];
    var arr = [];
    var a = document.getElementById("Start_roll");
    var Start_roll = a.options[a.selectedIndex].text;
    var b = document.getElementById("Start_col");
    var Start_col = b.options[b.selectedIndex].text;
    var c = document.getElementById("Start_dir");
    var Start_dir = c.options[c.selectedIndex].text;

    console.log(rows, cols, Start_roll, Start_col);

    for (i = 0; i < rows; i++) {
        arr[i] = [i];
        for (j = 0; j < cols; j++) {
            arr[i][j] = [j];
        }
    }
    console.log(arr);
    var myRover = {
        roverX: Start_roll,
        roverY: Start_col,
        direction: Start_dir
    };
    console.log(myRover);
    var alertLi = document.getElementsByClassName('list')[0];
    if (Start_roll > rows+1 || Start_col > cols+1) {
        alertLi.innerHTML += "<li style='color: red; font-size: xx-large; font-weight: inherit'>Error input or select, please refresh the page and try again</li>";
    }else {

        function goForward(rover) {
            switch (rover.direction) {
                case 'N':
                    rover.roverY ++;
                    if (rover.roverY > cols) {
                        rover.roverY = 0;

                    }
                    break;
                case 'E':
                    rover.roverX ++;
                    if (rover.roverX > rows) {
                        rover.roverX = 0;

                    }
                    break;
                case 'S':
                    rover.roverY --;
                    if (rover.roverY === -1) {
                        rover.roverY = 0;

                    }
                    break;
                case 'W':
                    rover.roverX --;
                    if (rover.roverX === -1) {
                        rover.roverX = 0;

                    }
                    break;
            }
            var dir = rover.direction;
            var R = rover.roverX;

            var C = rover.roverY;

            alertLi.innerHTML += "<li>New Rover Position: [" + R + ", " + C + ", forward : " + dir + "]</li>";
        }

        function goLeft(rover) {
            switch (rover.direction) {
                case 'N':
                    rover.direction = 'W';
                    break;
                case 'E':
                    rover.direction = 'N';
                    break;
                case 'S':
                    rover.direction = 'E';
                    break;
                case 'W':
                    rover.direction = 'S';
                    break;
            }
            var dir = rover.direction;
            alertLi.innerHTML += "<li>Turn Left [" + dir + "]</li>";
        }

        function goRight(rover) {
            switch (rover.direction) {
                case 'N':
                    rover.direction = 'E';
                    break;
                case 'E':
                    rover.direction = 'S';
                    break;
                case 'S':
                    rover.direction = 'W';
                    break;
                case 'W':
                    rover.direction = 'N';
                    break;
            }
            var dir = rover.direction;
            alertLi.innerHTML += "<li>Turn Right[" + dir + "]</li>";
        }

        var valueInput = document.getElementById("coordinates").value;

        for (var i = 0; i < valueInput.length; i++) {
            var count = valueInput.charAt(i);
            if (count === "M" || count === "f") {
                goForward(myRover);
            } else if (count === "R" || count === "r") {
                goRight(myRover);
            } else if (count === "L" || count === "l") {
                goLeft(myRover);
            } else {
                alertLi.innerHTML += "<li class='notFound'>Command not found</li>";
            }
        }

        return false;
    }
}

