# 📌 DataManagerApp - Aplicación de Gestión de Entidades

## 📝 Descripción

**DataManagerApp** es una aplicación de Windows Forms desarrollada en **C#** con **.NET**, diseñada para la gestión de diferentes tipos de entidades (películas, libros y revistas). El sistema simula una base de datos en memoria y permite realizar operaciones CRUD (Crear, Leer, Actualizar y Eliminar).

El proyecto se estructura en tres componentes principales: **Model**, **Repository** y **View**, asegurando un código limpio, escalable y mantenible.

---

## 📁 Estructura del Proyecto

```
📦 DataManagerApp
 ┣ 📂 Model         # Definición de entidades (Película, Libro, Revista, etc.)
 ┣ 📂 Repository    # Implementación de acceso a datos en memoria
 ┣ 📂 View          # Interfaz gráfica con Windows Forms
 ┣ 📜 Program.cs    # Punto de entrada de la aplicación
 ┣ 📜 README.md     # Documentación del proyecto
```

---

## 🏗 **1. Model (Modelos de Datos)**

Los modelos representan las entidades del sistema. Cada clase define la estructura de los datos manejados en la aplicación.

- **`IEntity`** → Interfaz base que define la estructura común de todas las entidades.
- **`Book`** 📖 → Representa un libro con título.
- **`Movie`** 🎬 → Representa una película con título y año de estreno.
- **`Magazine`** 📓 → Representa una revista con título y editorial.

Ejemplo:
```csharp
public class Movie : IEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }

    public Movie(string title, int year)
    {
        Title = title;
        Year = year;
    }
}
```

---

## 🗄 **2. Repository (Acceso a Datos)**

El acceso a datos se gestiona con el patrón **Repository**, permitiendo una implementación flexible y desacoplada. Cada entidad tiene su propio repositorio con operaciones **CRUD**:

- **`IBookRepository`**, **`IMovieRepository`**, **`IMagazineRepository`** → Interfaces que definen las operaciones necesarias.
- **`BookRepository`**, **`MovieRepository`**, **`MagazineRepository`** → Implementaciones concretas con datos en memoria.

Ejemplo de `MovieRepository`:
```csharp
public class MovieRepository : IMovieRepository
{
    private static readonly List<Movie> _movies = new();
    private static int _nextId = 1;

    public void Create(Movie movie)
    {
        movie.Id = _nextId++;
        _movies.Add(movie);
    }

    public Movie? FindById(int id) => _movies.FirstOrDefault(m => m.Id == id);

    public IEnumerable<Movie> GetAll() => _movies;

    public void Update(Movie movie)
    {
        var existingMovie = _movies.FirstOrDefault(m => m.Id == movie.Id);
        if (existingMovie != null)
        {
            existingMovie.Title = movie.Title;
            existingMovie.Year = movie.Year;
        }
    }

    public void Delete(int id) => _movies.RemoveAll(m => m.Id == id);
}
```

**✔️ Características**:
- **Inyección de dependencias (DI)** para un código desacoplado.
- **Uso de listas en memoria** en lugar de bases de datos reales, simplificando la implementación.

---

## 🎨 **3. View (Interfaz de Usuario)**

La vista es una aplicación **Windows Forms (WinForms)** que permite gestionar los datos de manera interactiva.

### 🖥 **Componentes de la Interfaz**
✔ **ComboBox** → Permite seleccionar la entidad (Libro, Película, Revista).  
✔ **DataGridView** → Muestra la lista de objetos de la entidad seleccionada.  
✔ **Botón Agregar** → Crea un nuevo objeto con valores predefinidos.  
✔ **Botón Eliminar** → Borra el objeto seleccionado.  
✔ **TextBox de Filtro** → Permite filtrar resultados por **ID, Título, Año o Editorial**.

Ejemplo:
```csharp
private void txtFiltro_TextChanged(object sender, EventArgs e)
{
    string filter = txtFilter.Text.ToLower().Trim();
    if (cmbEntities.SelectedItem == null) return;

    if (string.IsNullOrWhiteSpace(filter))
    {
        UpdateDataGridView();
        return;
    }

    dgvEntities.DataSource = cmbEntities.SelectedItem.ToString() switch
    {
        "Movie" => _movieRepository.GetAll().Where(m => 
            m.Id.ToString().Contains(filter) ||
            m.Title.ToLower().Contains(filter) ||
            m.Year.ToString().Contains(filter)).ToList(),

        "Book" => _bookRepository.GetAll().Where(b =>
            b.Id.ToString().Contains(filter) ||
            b.Title.ToLower().Contains(filter)).ToList(),

        "Magazine" => _magazineRepository.GetAll().Where(m =>
            m.Id.ToString().Contains(filter) ||
            m.Title.ToLower().Contains(filter) ||
            m.Editorial.ToLower().Contains(filter)).ToList(),

        _ => new List<object>()
    };
}
```

**✔️ Características**:
- **Interfaz intuitiva** y fácil de usar.
- **Soporte para múltiples entidades** con posibilidad de expansión futura.
- **Filtro avanzado** por ID, Título, Año y Editorial.

---

## ✅ **Conclusión**
Este proyecto implementa una **arquitectura limpia y escalable** con separación clara de responsabilidades.  
El código está diseñado para **soportar futuras ampliaciones** sin generar deuda técnica. 🚀  

> **💡 Nota:** Este repositorio puede servir como base para futuros proyectos en **ASP.NET** o **APIs REST** reutilizando la misma lógica. 🔥

---

¡Gracias por revisar DataManagerApp! 😊
