module Pages.HomePage

open State.Store
open State.Reducers

open Elmish

open Feliz

open Feliz.MaterialUI

let homePage = React.functionComponent( fun (model: Model, dispatch: Msg -> Unit) ->
    Mui.container  [
        container.maxWidth.xs
        
        prop.children [      
            
            
            Html.h1 [
                prop.text "Home"
            ]
        ]
    ]
)

