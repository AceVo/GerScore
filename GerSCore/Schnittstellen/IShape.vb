Public Interface IShape

    ReadOnly Property Level As Single
    Property Color As Color
    ReadOnly Property Bounds As Rectangle
    Function GetClosestSnapPoint(ByVal MousePosition As Point) As Point

    Sub Fokussieren()


End Interface
