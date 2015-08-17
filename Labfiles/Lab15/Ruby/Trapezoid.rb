include Math

class Trapezoid
=begin
   
   Attributes capture the shape of a Trapezoid:
  
          D----------------C
         /|                 \
        / |                  \
       /  |h                  \
      /   |                    \
     A----+---------------------B
=end

  attr_reader :vertexA # angles measured in degrees
  attr_reader :vertexB
  attr_reader :vertexC
  attr_reader :vertexD
  attr_reader :sideAB  # sides measured in unit lengths
  attr_reader :sideBC
  attr_reader :sideCD
  attr_reader :sideDA
  attr_reader :h         # distance between parallel sides
  
  def initialize(vertA, sAB, sCD, height)
=begin
  User specifies angles for vertex A and lengths of sideAB, and sideCD, 
  and the distance between these two parallel sides
  
  Length of side BC, sideDA, and angles for vertices B, C, and D are calculated
  
  Validation rules enforced:
  
    sideAB >= sideCD
    sideAB > 0
    sideBC > 0
    vertexA < 90
    height > 0
    
    additionally, vertexB must not be oblique when calculated (can happen if height + sideCD is large compared to sideAB)
    
=end

    if sAB < sCD
      raise "SideAB must not be shorter than SideCD"
    end
    
    if sAB <= 0
      raise "Length of SideAB must be greater than zero"
    end
    
    if sCD <= 0
      raise "Length of SideCD must be greater than zero"
    end
    
    if vertA >= 90
      raise "VertexA must be less than 90 degrees"
    end
    
    if height <= 0
      raise "Distance between parallel sides must be greater than zero"
    end
    
    @vertexA = vertA
    @vertexD = 180 - vertA # vertexA + vertexD must equal 180 degrees for sides to be parallel
    @sideAB = sAB
    @sideCD = sCD
    @h = height
    
=begin
   
          D----------------C
         /|                |\
        / |                | \
       /  |h              h|  \
      /   |                |   \
     A----F----------------E----B
          
  Calculations:
    To calculate sideDA
      sideDA = h / sin(vertexA)
    
    To calculate sideBC
      sideAF = h / tan(vertexA)
      sideEB = sideAB - sideFE - sideAF
             = sideAB - sideCD - sideAF
      sideBC = SQRT(h * h + sideEB * sideEB)
      
    To calculate vertexB
      vertexB = arctan(h / sideEB)
      
    To calculate vertexC
      vertexC = 180 - vertexB
  
  NOTE: The trig functions expect arguments in radians, so vertices must be converted from degrees:
  
    1 degree = PI / 180 radians
=end

    vertexAInRadians = Math::PI / 180 * vertA
    @sideDA = h / Math::sin(vertexAInRadians)
    
    sideAF = h / tan(vertexAInRadians)
    sideEB = sAB - sCD - sideAF
    @sideBC = Math::sqrt(h ** 2 + sideEB ** 2)
    
    vertexBInRadians = Math::atan(h / sideEB)
    vertexBInDegrees = vertexBInRadians * 180 / Math::PI
    if vertexBInDegrees <= 0
        raise "Height and length of SideCD are too big compared to SideAB"
    end
    @vertexB = vertexBInDegrees
    
    @vertexC = 180 - vertexBInDegrees

  end
  
  def to_s
    return "Vertex A:\t#{vertexA}\nSide AB:\t#{sideAB}\nVertex B:\t#{vertexB}\nSide BC:\t#{sideBC}\nVertex C:\t#{vertexC}\nSide CD:\t#{sideCD}\nVertex D:\t#{vertexD}\nSide DA:\t#{sideDA}"
  end
  
  def area()
=begin
   
   Area of trapezoid = 
     area of rectangular element + area of triangular elements
     
   Area of rectangular element = sideCD * h
   
   Area of triangular elements = (sideAF / 2 * h) + (sideEB / 2 * h)
                               = (sideAF + sideEB) / 2 * h
                               = (sideAB - sideCD) / 2 * h
  
          D----------------C
         /|                |\
        / |                | \
       /  |h              h|  \
      /   |                |   \
     A----F----------------E----B

=end

   areaOfRectangle = @sideCD * h
   sumOfAreasOfTriangles = (@sideAB - @sideCD) / 2 * h
   
   return areaOfRectangle + sumOfAreasOfTriangles
  end
 
end

def CreateTrapezoid(vertexA, sideAB, sideCD, height)
  return Trapezoid.new(vertexA, sideAB, sideCD, height)
end