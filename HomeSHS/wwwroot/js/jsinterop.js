function GetRoomPosition(id) {
    let elem = document.getElementById(id)
    let position = elem.getBoundingClientRect()

    let x = position.x.toString()
    let y = position.y.toString()

    result = x + " " + y

    return result
}