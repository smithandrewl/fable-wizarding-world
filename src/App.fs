module App

open Elmish
open Elmish.React
open Feliz

open Feliz.MaterialUI
open Feliz.MaterialUI.menu
open Fable.React

open State.Store
open State.Reducers

open Components.Login
    

let app = React.functionComponent( fun (model: Model, dispatch) ->
    Mui.container  [
        container.maxWidth.xs
        
        prop.children [      
            loginComponent (model, dispatch)
            
            Html.h1 [
                prop.text 
                    (match model.loginState with
                    | WaitingForInput -> ""
                    | LoginFailed     -> "Login Failed"
                    | LoginSucceeded  -> "Login Succeeded")
            ]
        ]
    ]
)

let view (model: Model) (dispatch: Msg -> Unit) =
    app (model, dispatch)

Program.mkSimple  (fun _ -> initModel) update view
|> Program.withReactSynchronous "root"
|> Program.run