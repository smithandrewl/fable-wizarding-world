module Pages.LoginPage

open Elmish
open Elmish.React

open Feliz

open Feliz.MaterialUI
open Components.Login
open State.Store

let loginPage = React.functionComponent( fun (model: Model, dispatch) ->
    Mui.container  [
        container.maxWidth.xs
        
        prop.children [      
            loginComponent (model, dispatch)
            
            Html.h1 [
                prop.text 
                    (match model.loginSection.state with
                    | LoginState.WaitingForInput -> ""
                    | LoginState.LoginFailed     -> "Login Failed"
                    | LoginState.LoginSucceeded  -> "Login Succeeded")
            ]
        ]
    ]
)

