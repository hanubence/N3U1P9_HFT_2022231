let data = fetch('http://localhost:5000/Shelter').
    then(x => x.json()).
    then(x => console.log(x))