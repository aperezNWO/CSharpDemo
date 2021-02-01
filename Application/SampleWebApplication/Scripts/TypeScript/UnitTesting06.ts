//
class UserAccount {
    name: string;
    id: number;

    constructor(name: string, id: number) {
        this.name = name;
        this.id = id;
    }

    GetAdminUser(): User {
        //...
        var user: User;

        return user;
    }

}

function getAdminUser(): User {
    //...
    var user: User;

    return user;
}

function deleteUser(user: User) {
    // ...
}

//
type WindowStates = "open" | "closed" | "minimized";
type LockStates = "locked" | "unlocked";
type OddNumbersUnderTen = 1 | 3 | 5 | 7 | 9;

//
interface User {
    name: string;
    id: number;
};

//
const user: User = {
    name: "Hayes",
    id: 0,
};

//
const obj = { width: 10, height: 15 };
const area = obj.width * obj.height;


//
const userAccount = new UserAccount("Alejandro", 1);


//----------------------------------------------------------------
//----------------------------------------------------------------


