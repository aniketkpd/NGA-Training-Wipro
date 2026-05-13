(function () {
    const state = {
        page: 1,
        pageSize: 5,
        totalPages: 1
    };

    const modalEl = document.getElementById("bookModal");
    const bookModal = new bootstrap.Modal(modalEl);

    function message(text, type) {
        const box = document.getElementById("messageBox");
        box.innerHTML = `<div class="alert alert-${type} py-2">${text}</div>`;
        setTimeout(() => box.innerHTML = "", 2500);
    }

    async function loadBooks() {
        const query = new URLSearchParams({
            search: document.getElementById("searchInput").value,
            authorId: document.getElementById("authorFilter").value,
            genreId: document.getElementById("genreFilter").value,
            sortBy: document.getElementById("sortBy").value,
            page: state.page,
            pageSize: state.pageSize
        });

        try {
            const res = await fetch(`/Library/Books?${query.toString()}`);
            if (!res.ok) throw new Error("Could not fetch books.");
            const data = await res.json();
            state.totalPages = data.totalPages || 1;
            renderTable(data.items);
            document.getElementById("pageInfo").textContent = `Page ${data.currentPage} of ${data.totalPages} | Total: ${data.totalCount}`;
        } catch (err) {
            message(err.message, "danger");
        }
    }

    async function loadAuthors() {
        const res = await fetch("/Library/Authors");
        const authors = await res.json();
        const list = document.getElementById("authorsList");
        list.innerHTML = "";
        authors.forEach(a => {
            list.innerHTML += `<li class="list-group-item d-flex justify-content-between align-items-center">
                <span>${a.name}</span>
                <span>
                    <button class="btn btn-sm btn-warning me-1 author-edit" data-id="${a.id}" data-name="${a.name}">Edit</button>
                    <button class="btn btn-sm btn-danger author-delete" data-id="${a.id}">Delete</button>
                </span>
            </li>`;
        });
        document.querySelectorAll(".author-edit").forEach(btn => btn.addEventListener("click", editAuthor));
        document.querySelectorAll(".author-delete").forEach(btn => btn.addEventListener("click", deleteAuthor));

        const authorFilter = document.getElementById("authorFilter");
        const authorInput = document.getElementById("authorInput");
        const existingFilter = authorFilter.value;
        authorFilter.innerHTML = `<option value="">All</option>`;
        authorInput.innerHTML = "";
        authors.forEach(a => {
            authorFilter.innerHTML += `<option value="${a.id}">${a.name}</option>`;
            authorInput.innerHTML += `<option value="${a.id}">${a.name}</option>`;
        });
        authorFilter.value = existingFilter;
    }

    async function loadGenres() {
        const res = await fetch("/Library/Genres");
        const genres = await res.json();
        const list = document.getElementById("genresList");
        list.innerHTML = "";
        genres.forEach(g => {
            list.innerHTML += `<li class="list-group-item d-flex justify-content-between align-items-center">
                <span>${g.name}</span>
                <span>
                    <button class="btn btn-sm btn-warning me-1 genre-edit" data-id="${g.id}" data-name="${g.name}">Edit</button>
                    <button class="btn btn-sm btn-danger genre-delete" data-id="${g.id}">Delete</button>
                </span>
            </li>`;
        });
        document.querySelectorAll(".genre-edit").forEach(btn => btn.addEventListener("click", editGenre));
        document.querySelectorAll(".genre-delete").forEach(btn => btn.addEventListener("click", deleteGenre));

        const genreFilter = document.getElementById("genreFilter");
        const genreInput = document.getElementById("genreInput");
        const existingFilter = genreFilter.value;
        genreFilter.innerHTML = `<option value="">All</option>`;
        genreInput.innerHTML = "";
        genres.forEach(g => {
            genreFilter.innerHTML += `<option value="${g.id}">${g.name}</option>`;
            genreInput.innerHTML += `<option value="${g.id}">${g.name}</option>`;
        });
        genreFilter.value = existingFilter;
    }

    function renderTable(items) {
        const tbody = document.getElementById("booksTbody");
        tbody.innerHTML = "";
        if (!items || items.length === 0) {
            tbody.innerHTML = `<tr><td colspan="5" class="text-center">No books found.</td></tr>`;
            return;
        }

        for (const item of items) {
            tbody.innerHTML += `
            <tr>
                <td>${item.title}</td>
                <td>${item.authorName}</td>
                <td>${item.publishedYear}</td>
                <td>${item.genres.join(", ")}</td>
                <td>
                    <button class="btn btn-sm btn-warning edit-btn" data-id="${item.id}">Edit</button>
                    <button class="btn btn-sm btn-danger delete-btn" data-id="${item.id}">Delete</button>
                </td>
            </tr>`;
        }

        document.querySelectorAll(".edit-btn").forEach(btn => btn.addEventListener("click", onEdit));
        document.querySelectorAll(".delete-btn").forEach(btn => btn.addEventListener("click", onDelete));
    }

    async function onEdit(e) {
        const id = e.target.dataset.id;
        try {
            const res = await fetch(`/Library/Book?id=${id}`);
            if (!res.ok) throw new Error("Could not load book.");
            const b = await res.json();
            document.getElementById("bookId").value = b.id;
            document.getElementById("titleInput").value = b.title;
            document.getElementById("isbnInput").value = b.isbn || "";
            document.getElementById("yearInput").value = b.publishedYear;
            document.getElementById("authorInput").value = b.authorId;

            const genreSelect = document.getElementById("genreInput");
            Array.from(genreSelect.options).forEach(o => {
                o.selected = b.genreIds.includes(parseInt(o.value, 10));
            });
            bookModal.show();
        } catch (err) {
            message(err.message, "danger");
        }
    }

    async function onDelete(e) {
        if (!confirm("Delete this book?")) return;
        const id = e.target.dataset.id;
        try {
            const res = await fetch(`/Library/DeleteBook?id=${id}`, { method: "DELETE" });
            const payload = await res.json();
            if (!res.ok) throw new Error(payload.message || "Delete failed.");
            message(payload.message, "success");
            await loadBooks();
        } catch (err) {
            message(err.message, "danger");
        }
    }

    async function saveBook() {
        const genreIds = Array.from(document.getElementById("genreInput").selectedOptions)
            .map(o => parseInt(o.value, 10));

        const payload = {
            id: document.getElementById("bookId").value || null,
            title: document.getElementById("titleInput").value,
            isbn: document.getElementById("isbnInput").value,
            publishedYear: parseInt(document.getElementById("yearInput").value, 10),
            authorId: parseInt(document.getElementById("authorInput").value, 10),
            genreIds
        };

        const isEdit = !!payload.id;
        const url = isEdit ? "/Library/UpdateBook" : "/Library/CreateBook";
        const method = isEdit ? "PUT" : "POST";

        try {
            const res = await fetch(url, {
                method,
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify(payload)
            });
            const response = await res.json();
            if (!res.ok) throw new Error(response.message || "Save failed.");
            message(response.message, "success");
            bookModal.hide();
            await loadBooks();
            await loadAuthors();
            await loadGenres();
        } catch (err) {
            message(err.message, "danger");
        }
    }

    function clearModal() {
        document.getElementById("bookId").value = "";
        document.getElementById("titleInput").value = "";
        document.getElementById("isbnInput").value = "";
        document.getElementById("yearInput").value = "";
        document.getElementById("authorInput").selectedIndex = 0;
        Array.from(document.getElementById("genreInput").options).forEach(o => o.selected = false);
    }

    document.getElementById("newBookBtn").addEventListener("click", () => {
        clearModal();
        bookModal.show();
    });

    document.getElementById("saveBookBtn").addEventListener("click", saveBook);

    document.getElementById("applyFiltersBtn").addEventListener("click", () => {
        state.page = 1;
        loadBooks();
    });

    document.getElementById("prevBtn").addEventListener("click", () => {
        if (state.page > 1) {
            state.page--;
            loadBooks();
        }
    });

    document.getElementById("nextBtn").addEventListener("click", () => {
        if (state.page < state.totalPages) {
            state.page++;
            loadBooks();
        }
    });

    async function addAuthor() {
        const name = document.getElementById("authorNameInput").value;
        const res = await fetch("/Library/CreateAuthor", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(name)
        });
        const data = await res.json();
        if (!res.ok) throw new Error(data.message || "Failed to add author.");
        document.getElementById("authorNameInput").value = "";
        message(data.message, "success");
        await loadAuthors();
    }

    async function addGenre() {
        const name = document.getElementById("genreNameInput").value;
        const res = await fetch("/Library/CreateGenre", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(name)
        });
        const data = await res.json();
        if (!res.ok) throw new Error(data.message || "Failed to add genre.");
        document.getElementById("genreNameInput").value = "";
        message(data.message, "success");
        await loadGenres();
    }

    async function editAuthor(e) {
        const id = parseInt(e.target.dataset.id, 10);
        const name = prompt("Update author name", e.target.dataset.name);
        if (!name) return;
        const res = await fetch("/Library/UpdateAuthor", {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ id, name })
        });
        const data = await res.json();
        if (!res.ok) throw new Error(data.message || "Failed to update author.");
        message(data.message, "success");
        await loadAuthors();
    }

    async function editGenre(e) {
        const id = parseInt(e.target.dataset.id, 10);
        const name = prompt("Update genre name", e.target.dataset.name);
        if (!name) return;
        const res = await fetch("/Library/UpdateGenre", {
            method: "PUT",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ id, name })
        });
        const data = await res.json();
        if (!res.ok) throw new Error(data.message || "Failed to update genre.");
        message(data.message, "success");
        await loadGenres();
    }

    async function deleteAuthor(e) {
        if (!confirm("Delete this author?")) return;
        const id = e.target.dataset.id;
        const res = await fetch(`/Library/DeleteAuthor?id=${id}`, { method: "DELETE" });
        const data = await res.json();
        if (!res.ok) throw new Error(data.message || "Failed to delete author.");
        message(data.message, "success");
        await loadAuthors();
    }

    async function deleteGenre(e) {
        if (!confirm("Delete this genre?")) return;
        const id = e.target.dataset.id;
        const res = await fetch(`/Library/DeleteGenre?id=${id}`, { method: "DELETE" });
        const data = await res.json();
        if (!res.ok) throw new Error(data.message || "Failed to delete genre.");
        message(data.message, "success");
        await loadGenres();
    }

    document.getElementById("addAuthorBtn").addEventListener("click", () => {
        addAuthor().catch(err => message(err.message, "danger"));
    });
    document.getElementById("addGenreBtn").addEventListener("click", () => {
        addGenre().catch(err => message(err.message, "danger"));
    });

    loadBooks();
    loadAuthors().catch(err => message(err.message, "danger"));
    loadGenres().catch(err => message(err.message, "danger"));
})();
