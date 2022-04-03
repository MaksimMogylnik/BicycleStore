let bicycles
var tokenKey = "accessToken"

const toBase64 = file => new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result);
    reader.onerror = error => reject(error);
});

async function getBicycles() {

    const token = sessionStorage.getItem(tokenKey)

    const response = await fetch('/api/bicycle', {
        method: 'GET',
        headers: {
            'Authorization': 'bearer ' + token
        }
    })

    if (response.ok === true) {
        bicycles = await response.json()
        console.log(bicycles)
        let rows = document.querySelector('tbody')
        bicycles.forEach(bicycle => rows.append(createTableRow(bicycle)))
    }
}

function createTableRow(bicycle) {
    const tr = document.createElement('tr')
    tr.id = bicycle.bicycleId

    const titleTd = document.createElement('td')
    titleTd.append(bicycle.bicycleTitle)
    tr.append(titleTd)

    const pictureTd = document.createElement('td')
    const pictureImg = document.createElement('img')
    pictureImg.src = `${bicycle.bicycleImage}`
    pictureImg.style.width = '128px'
    pictureImg.style.height = '64px'
    pictureTd.append(pictureImg)
    tr.append(pictureTd)

    const weightTd = document.createElement('td')
    weightTd.append(bicycle.bicycleWeight)
    tr.append(weightTd)

    const materialTd = document.createElement('td')
    materialTd.append(bicycle.bicycleMaterial)
    tr.append(materialTd)

    const colorTd = document.createElement('td')
    colorTd.append(bicycle.bicycleColor)
    tr.append(colorTd)

    const wheelDiameterTd = document.createElement('td')
    wheelDiameterTd.append(bicycle.bicycleWheelDiameter)
    tr.append(wheelDiameterTd)

    const additionalInfoTd = document.createElement('td')
    additionalInfoTd.append(bicycle.bicycleAdditionalInfo)
    tr.append(additionalInfoTd)

    const priceTd = document.createElement('td')
    priceTd.append(bicycle.bicyclePrice)
    tr.append(priceTd)

    let del = document.createElement('a');
    del.classList.add('btn', 'btn-danger');
    del.setAttribute('value', bicycle.bicycleId);
    del.innerText = 'Delete';
    del.addEventListener('click', function (e) {
        let value = e.target.getAttribute('value');
        var row = document.getElementById(value);
        document.querySelector('tbody').removeChild(row);

        fetch('/Api/Bicycle/' + value,
            { method: 'DELETE' });
    });
    tr.append(del)

    let edit = document.createElement('a');
    edit.classList.add('btn', 'btn-info');
    edit.setAttribute('value', bicycle.bicycleId);
    edit.innerText = 'Edit';
    edit.addEventListener('click', function (e) {
        let value = e.target.getAttribute('value');
        let bicycle = bicycles.find(b => b.bicycleId == value)

        form.elements['bicycleTitle'].value = bicycle.bicycleTitle

        form.elements['bicycleImage'].value = bicycle.bicycleImage

        form.elements['bicycleWeight'].value = bicycle.bicycleWeight
        form.elements['bicycleMaterial'].value = bicycle.bicycleMaterial
        form.elements['bicycleColor'].value = bicycle.bicycleColor
        form.elements['bicycleWheelDiameter'].value = bicycle.bicycleWheelDiameter
        form.elements['bicycleAdditionalInfo'].value = bicycle.bicycleAdditionalInfo
        form.elements['bicyclePrice'].value = bicycle.bicyclePrice

        id = document.getElementById('bicycleId')
        id.value = bicycle.bicycleId
    });
    tr.append(edit)

    return tr
}

async function createBicycle(BicycleTitle, BicycleImage, BicycleWeight, BicycleMaterial, BicycleColor, BicycleWheelDiameter, BicycleAdditionalInfo, BicyclePrice) {

    if (BicycleWeight == "") {
        BicycleWeight = 0
    }
    if (BicyclePrice == "") {
        BicyclePrice = 0
    }

    const token = sessionStorage.getItem(tokenKey)

    const response = await fetch('Api/Bicycle', {
        method: 'POST',
        headers: { 'Accept': 'application/json', 'Content-Type': 'application/json', 'Authorization': 'bearer ' + token},
        body: JSON.stringify({
            bicycleTitle: BicycleTitle,
            bicycleImage: BicycleImage,
            bicycleWeight: parseInt(BicycleWeight),
            bicycleMaterial: BicycleMaterial,
            bicycleColor: BicycleColor,
            bicycleWheelDiameter: BicycleWheelDiameter,
            bicycleAdditionalInfo: BicycleAdditionalInfo,
            bicyclePrice: parseInt(BicyclePrice)
        })
    })

    if (response.ok === true) {
        getBicycles()
    }
    else {
        const errorData = await response.json()
        console.log(errorData)
        console.log(errorData.errors)
        if (errorData) {
            if (errorData.errors) {

                if (errorData.errors["BicycleTitle"]) {
                    showError(errorData.errors["BicycleTitle"])
                }

                if (errorData.errors["BicyclePrice"]) {
                    showError(errorData.errors["BicyclePrice"])
                }

            }
            else {
                if (errorData["BicycleTitle"]) {
                    showError(errorData["BicycleTitle"])
                    console.log(errorData["BicycleTitle"])
                }

                if (errorData["BicyclePrice"]) {
                    showError(errorData["BicyclePrice"])
                    console.log(errorData["BicyclePrice"])
                }
            }


            document.getElementById('errors').style.display = 'block'
        }
    }
}

function showError(errors) {
    errors.forEach(error => {
        const p = document.createElement('p')
        p.append(error)
        document.getElementById('errors').append(p)
    })
}

async function updateBicycle(BicycleId, BicycleImage, BicycleTitle, BicycleWeight, BicycleMaterial, BicycleColor, BicycleWheelDiameter, BicycleAdditionalInfo, BicyclePrice) {

    if (BicycleWeight == "") {
        BicycleWeight = 0
    }
    if (BicyclePrice == "") {
        BicyclePrice = 0
    }
    const token = sessionStorage.getItem(tokenKey)

    const response = await fetch('Api/Bicycle', {
        method: 'PUT',
        headers: { 'Accept': 'application/json', 'Content-Type': 'application/json', 'Authorization': 'bearer ' + token },
        body: JSON.stringify({
            bicycleId: BicycleId,
            bicycleTitle: BicycleTitle,
            bicycleImage: BicycleImage,
            bicycleWeight: parseInt(BicycleWeight),
            bicycleMaterial: BicycleMaterial,
            bicycleColor: BicycleColor,
            bicycleWheelDiameter: BicycleWheelDiameter,
            bicycleAdditionalInfo: BicycleAdditionalInfo,
            bicyclePrice: parseInt(BicyclePrice)
        })
    })

    if (response.ok === true) {
        const bicycle = await response.json()
        document.querySelector('tbody').append(createTableRow(bicycle))
    }
    else {
        const errorData = await response.json()
        console.log(errorData)
        console.log(errorData.errors)
        if (errorData) {
            if (errorData.errors) {

                if (errorData.errors["BicycleTitle"]) {
                    showError(errorData.errors["BicycleTitle"])
                }

                if (errorData.errors["BicyclePrice"]) {
                    showError(errorData.errors["BicyclePrice"])
                }

            }
            else {
                if (errorData["BicycleTitle"]) {
                    showError(errorData["BicycleTitle"])
                    console.log(errorData["BicycleTitle"])
                }

                if (errorData["BicyclePrice"]) {
                    showError(errorData["BicyclePrice"])
                    console.log(errorData["BicyclePrice"])
                }
            }


            document.getElementById('errors').style.display = 'block'
        }
    }
}

form = document.forms['bicycleForm']
let add = document.getElementById('submit')
add.addEventListener('click', async function (e) {
    e.preventDefault()

    const bicycleTitle = form.elements['bicycleTitle'].value
    const bicycleImage = await toBase64(form.elements['bicycleImage'].files[0])
    const bicycleWeight = form.elements['bicycleWeight'].value
    const bicycleMaterial = form.elements['bicycleMaterial'].value
    const bicycleColor = form.elements['bicycleColor'].value
    const bicycleWheelDiameter = form.elements['bicycleWheelDiameter'].value
    const bicycleAdditionalInfo = form.elements['bicycleAdditionalInfo'].value
    const bicyclePrice = form.elements['bicyclePrice'].value

    createBicycle(bicycleTitle, bicycleImage, bicycleWeight, bicycleMaterial, bicycleColor, bicycleWheelDiameter, bicycleAdditionalInfo, bicyclePrice)
})

let save = document.getElementById('save')
save.addEventListener('click', async function (e) {
    e.preventDefault()

    const bicycleTitle = form.elements['bicycleTitle'].value
    const bicycleImage = await toBase64(form.elements['bicycleImage'].files[0])
    const bicycleWeight = form.elements['bicycleWeight'].value
    const bicycleMaterial = form.elements['bicycleMaterial'].value
    const bicycleColor = form.elements['bicycleColor'].value
    const bicycleWheelDiameter = form.elements['bicycleWheelDiameter'].value
    const bicycleAdditionalInfo = form.elements['bicycleAdditionalInfo'].value
    const bicyclePrice = form.elements['bicyclePrice'].value

    const bicycleId = document.getElementById('bicycleId').value

    updateBicycle(bicycleId, bicycleImage, bicycleTitle, bicycleWeight, bicycleMaterial, bicycleColor, bicycleWheelDiameter, bicycleAdditionalInfo, bicyclePrice)
})


getBicycles()

async function getTokenAsync() {
    const credentials = {
        email: document.querySelector('#email').value,
        password: document.querySelector('#password').value
    }

    const response = await fetch('api/account/token', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(credentials)
    })

    const data = await response.json()
    if (response.ok === true) {
        sessionStorage.setItem(tokenKey, data.access_token)
        getBicycles()
    } else {
        console.log(response.status, data.errorText)
    }
}

document.getElementById('submitLogin').addEventListener('click', function () {
    getTokenAsync()
    alert('Access token has been created')
})

