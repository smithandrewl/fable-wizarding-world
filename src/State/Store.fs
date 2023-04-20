module State.Store

type LoginState =
    | WaitingForInput
    | LoginFailed
    | LoginSucceeded
    

type Model = {
    username:   string
    password:   string
    loginState: LoginState
}
    
let initModel = {
    username = ""
    password = ""
    loginState = WaitingForInput
}