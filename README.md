# Setup
A simple reflex agent for a vacuum cleaner world with graphical representation.

## Create New Project
1. Open Visual Studio Community
2. Click 'Create a new project'
3. Choose 'Windows Forms App'
4. Enter 'Activity1' as the title

## Forms UI
1. On the left side click Toolbox or if you can't find it click View -> Toolbox.
2. Find RichTextBox or type in the search bar. The default name will be `richTextBox1` which you will use in the Forms.cs code. Drag to the Form or double-click.
3. Find Button or type in the search bar. The default name will be `button1` which you will use in the Forms.cs code. Drag to the Form or double-click.
4. Find PictureBox or type in the search bar. The default name will be `pictureBox1` which you will use in the Forms.cs code. Drag to the Form or double-click.

### Button Setup
1. Right-click  `button1` in Designer View and click `Properties`.
2. Go to Events (Lightning Icon).
3. Go to Action -> Click.
4. Type the function name `button1_Click` and it will automatically declare the function in Form.cs.

### Graphics Setup (PictureBox)
1. Right-click  `pictureBox1` in Designer View and click `Properties`.
2. Go to Events (Lightning Icon).
3. Go to Action -> Click.
4. Type the function name `pictureBox1_Paint` and it will automatically declare the function in Form.cs.
5. Go to the Properties (Wrench Icon) and make sure the Size property is set to `120, 120`.

---

Enjoy coding!
