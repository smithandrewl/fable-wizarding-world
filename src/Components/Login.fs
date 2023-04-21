module Components.Login

open Feliz
open Feliz.MaterialUI

open State.Store
open State.Reducers

let loginComponent =
    React.functionComponent( fun (model: Model, dispatch: Msg -> Unit) ->
        Html.form [
            
            prop.children [
                Mui.textField [
                    prop.label "Username"
                    prop.onChange  (fun (username) -> dispatch (Msg.LoginFormUpdated(username, model.loginSection.password)))
                    textField.variant.outlined
                    textField.margin.normal
                    textField.fullWidth true
                ]
                
                Mui.textField [
                    prop.label "Password"
                    prop.onChange (fun(password) -> dispatch (Msg.LoginFormUpdated(model.loginSection.username, password)))
                    textField.variant.outlined
                    textField.fullWidth true
                    
                ]
                
                Mui.button [
                    prop.className "submit"
                    prop.text "Login"
                    prop.onClick (fun (event) -> dispatch Msg.LoginSubmission)
                    button.variant.contained
                    button.color.primary
                    button.fullWidth true
                    
                ]
            ]
        ]
    )