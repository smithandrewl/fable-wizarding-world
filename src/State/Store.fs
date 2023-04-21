module State.Store

open Feliz
open Feliz.Router
open Elmish
open Elmish.React

open Feliz
open Feliz.Router

open Feliz.MaterialUI
open Feliz.MaterialUI.menu
open Fable.React

type Page =
    | Home
    | NotFound
    
type LoginState =
    | WaitingForInput
    | LoginFailed
    | LoginSucceeded
    
type LoginSectionState = {
    username: string
    password: string
    state: LoginState
}
    
type Model = {
    loginSection: LoginSectionState
    currentUrl: string list
}
    
let initModel = {
    loginSection = {
        username = ""
        password = ""
        state = WaitingForInput
    }
    
    currentUrl = Router.currentUrl() 
}