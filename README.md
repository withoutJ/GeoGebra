# GeoGebra u C#
This application is the result of joint efforts by Petar Samardžić and Momčilo Mrkaić as part of a project for our Object-Oriented Programming class. Since this was a project for our high-school class, some of the words/names in the code are in Serbian.

# Class Matrica

- **Attributes**

The only attribute is float [,] mat, which represents the given matrix.

- **Constructors**

Empty constructor and a constructor based on attributes.

- **Properties**

Properties N and M, which return the length and width of the matrix, and the Mat property, which can set and return the matrix.

- **Operators**

The \* operator for matrix multiplication.

# Class Tacka

This class inherits from the Matrica class.

- **Attributes**

We have a static attribute NT that indicates the current number of created points, string name, and Color color attributes.

- **Constructors**

Copy constructor, empty constructor, and a constructor based on attributes.

- **Properties**

Properties to return the name, color, x, and y coordinates of the point, and a PointF property that returns a PointF type point.

- **Methods**

void Crtaj(graphics, scaling factor, origin) - for drawing the point.
float Rastojanje(Tacka T) - distance from another point.
float Rastojanje(Prava p) - distance from a line.
float Rastojanje(Duz d) - distance from a segment.
float Rastojanje(Krug k) - distance from the center of a circle.

We have created methods like Najblizi that return the closest object to the given point (the index of that object in the corresponding array). We did this so that we can highlight an object if someone clicks in its vicinity, allowing the user to select the object closest to where they clicked, rather than having to click exactly on the pixel where the object is located.

int Najblizi(array of lines containing all created lines) - the closest line to the given point.
int Najblizi(array of segments) - the closest segment to the given point.
int Najblizi(array of circles) - the closest circle to the given point.
int Najblizi(array of points) - the closest point to the given point.

Now we have a series of classes that inherit from the Matrica class. They represent matrices of isometric transformations. When, for example, we want to translate a point, we obtain its image by multiplying the matrix of that point by the translation matrix. This is why we represent points and isometries in the form of matrices. In the following four classes, we have only one constructor that creates the matrix for that isometry. The classes are: **Translacija, Rotacija, Homotetija,** and **Refleksija**.

# Class Prava

- **Attributes**

We have a static attribute NP that indicates the number of created lines, float k, float n attributes (we represent a line as y = k\*x + n), and a string name.

- **Constructors**

Constructor with two points and a name, and a constructor based on attributes.

- **Properties**

Properties to return the coefficient, intersection with the y-axis, and name.

- **Methods**

void Crtaj(graphics, scaling factor, origin, array of objects, object type, RadioButton showhide, pictureBox) - method for drawing the line.
bool Pripada(Tacka T) - whether the point belongs to the line.

Prava Normala(Tacka T) - the normal from a point to the line.
Prava Paralela(Tacka T) - a line parallel to the given line through a point.

double Ugao(Prava p) and double Ugao(Duz d) - the angle between the given line and another line, or segment.

Prava SimetralaUgla(Prava p) - the angle bisector between the given line and another line.
Prava SimetralaUgla(Duz d) - the angle bisector between the given line and a segment.

Then we have Presek methods that return a Tacka type object, i.e., the intersection point of the given line with a segment, another line, or a circle.

The last methods are transformations of the given line using isometric transformations.

# Class Duz

A segment is quite similar to a line, so we made it inherit from the Line class.

- **Attributes**

We have a static attribute ND that indicates the number of created segments, and attributes Point A and Point B, which are the endpoints of the segment.

- **Constructors**

Constructor based on attributes.

- **Properties**

Properties FirstPoint and SecondPoint, which return the first and second points of the segment.

- **Methods**

New methods that are not present in the Prava class are: Prava Simetrala() - the bisector of the given segment.

void PravilanMnogougao(number of vertices, array of points, array of segments, array of objects) - create a regular polygon with n sides, where one side is the given segment. Also, add the newly obtained points and segments to the corresponding arrays.

# Class Krug

- **Attributes**

We have a static attribute NK that indicates the number of created circles. Point C is the center of the circle, double r is the radius, and we also have a string name.

- **Constructors**

Constructors based on attributes, constructors with 3 points (needed for the construction of a circle), constructors with 2 points (center and a point on the circle), and constructors with a segment and a point (compass).

- **Properties**

Properties to return the center, radius, and name.

- **Methods**

We have methods for drawing the circle, checking if a point belongs to the circle, finding intersections of the circle with other objects, and isometric transformations.

What's new for the circle are tangents from a point to the circle and inversion.

void Tangente(Tacka T, array of lines, array of objects) - if the point belongs to the circle, it returns one tangent; if not, it creates both tangents, if the point is inside the circle, it does nothing.

In inversions, we have 5 functions: 
Tacka Inverzija(Tacka T) - the inverse image of a point relative to the circle, which is the second point;
Prava Inverzija(Prava p) - the inverse image of a line relative to the circle when the center of the circle belongs to the line, which returns a line;
Krug Inverzija(Prava p) - the inverse image of a line relative to the circle when the line does not contain the center of the circle, which returns a circle; 
Krug Inverzija(Krug k) - the inverse image of a circle when the circle does not contain the center of inversion, which is a new circle;
Prava Inverzija(Krug k) - the inverse image of a circle when it contains the center of inversion, which results in a new line.

# FORMA (APPLICATION)

- **Initialization**

Setting static attributes (origin, system size - constant k). Initialize arrays of objects (all together), points, lines, segments, and circles. When adding each object for use, place it in the appropriate array and register changes by increasing the number of objects in each array.

- **Variables**

Introduce all the variables that will be needed and define the arrays mentioned earlier.

- **Methods**

Formulate the calls to all methods from the classes related to drawing: Reset, resets the drawing state - finishing the construction of an object, sets the values of variables j1, j2, j3 to 0, and returns the initial color of the points; Undo, go back one step (each step is registered); Labeling, assign names to the introduced objects; Closest, for a given point, find the object from the array of objects that is closest to it, where the distance between objects is defined in the classes; Add, add objects to the appropriate arrays.

- **Paint**

Color the points introduced by clicking on the surface in blue, and the points obtained as intersections

 of objects (e.g., the intersection of two lines) in black. In the drawing state, when we select a point for use, it becomes green.

- **Radio Buttons**

Introduce the necessary objects of the RadioButton class to select the option we want when drawing (by selecting the corresponding Radio Button, we execute the desired action).

- **Zoom**

Increase (zoom in) or decrease (zoom out) the scaling factor k, which results in changing the sizes of the shapes we've drawn.

- **Obrisi sve**

Clear the entire content, clean the drawing surface.

- **Pomeraj**

By clicking the button, call the Undo method.

- **Move**

Translate the drawing surface by selecting two points, and translate the selected object by the vector determined by those points.

- **Mouse Click**

# MOUSE CLICK (instructions for constructing objects)

- **Tacka**

By clicking on the surface, create a new point, add it to the arrays of objects and points, and color it blue.

- **Duz**

By clicking on two points and choosing the Crtanje Duzi option, create a new segment, add it to the arrays of objects and segments.

- **Prava**

By clicking on two points and choosing the Crtanje Prave option, create a new line, add it to the arrays of objects and lines.

- **Paralela / Normala**

By clicking on a point and a line, construct a parallel or normal line through that point, then add it to the arrays of lines and objects.

- **Simetrala ugla**

Select two lines and an angle vertex, construct the angle bisector, add it to the arrays of lines and objects.

- **Simetrala duzi**

Select two points and use this option to construct the segment bisector between those two points, then add it to the arrays of lines and objects.

- **Mnogougao**

Select a segment and use this option to specify the number of vertices for the polygon. Each subsequent vertex is constructed by rotating the previous one around the last one for an angle of (n-2) * pi/n, resulting in a regular n-gon.

- **Tangente**

By selecting a point and a circle, use this option to construct two tangents from this point to the given circle if it is not located inside the circle. These two lines are added to the arrays of lines and objects.

- **Presek**

By selecting two objects (lines/segments/circles), construct points that are the intersections of those objects.

- **Duz date duzine**

By selecting a point and entering the desired length, construct a segment of that length, parallel to the x-axis of the coordinate system.

- **Ugao date velicine**

By selecting the angle vertex, an arm, and entering the angle size, construct the second arm of the angle.

- **Merenje duzi/ugla**

By selecting one of these options, calculate and display its size.

# Circle Constructions

- **Centar i tacka na krugu**

Select the center of the circle and a point on it to construct the desired circle.

- **Centar i poluprecnik**

Select the center and enter the radius to construct the circle.

- **Tri tacke**

Select three points to construct a circle through them using this option.

- **Nalazenje centra kruga**

By selecting a specific circle, construct a point that is its center.

# Transformations

- **Homotetija**

By selecting the center of the homothety and entering the coefficient, construct the object obtained by the given homothety and place it in the appropriate arrays.

- **Translacija**

By selecting two points, translate the selected object by the vector determined by those points.

- **Refleksija**

By selecting the axis of reflection and the object, use this option to map the selected object over that line.

- **Rotacija**

By selecting the center of rotation, clicking on the point to be rotated, and entering the rotation angle (in degrees), construct the rotated point.

- **Inverzija**

By selecting a point and a circle, use this option to construct the inverse image of the point relative to the given circle (analyzing whether it is inside the circle, outside it, or on the circle).
