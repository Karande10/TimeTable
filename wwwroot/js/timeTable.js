document.addEventListener('DOMContentLoaded', function () {
    // Initial Form Logic
    const initialForm = document.getElementById('initialForm');
    if (initialForm) {
        const noOfWorkingDays = document.getElementById('NoOfWorkingDays');
        const noOfSubjectsPerDay = document.getElementById('NoOfSubjectsPerDay');
        const totalSubjects = document.getElementById('TotalSubjects');
        const totalHoursForWeek = document.getElementById('TotalHoursForWeek');
        const submitButton = document.getElementById('submitButton');

        function calculateInitialTotalHours() {
            const days = parseInt(noOfWorkingDays.value) || 0;
            const subs = parseInt(noOfSubjectsPerDay.value) || 0;
            totalHoursForWeek.value = days * subs;

            const isValid = days >= 1 && days <= 7 &&
                subs >= 1 && subs <= 8 &&
                parseInt(totalSubjects.value) > 0;

            submitButton.disabled = !isValid;
        }

        [noOfWorkingDays, noOfSubjectsPerDay, totalSubjects].forEach(input => {
            input.addEventListener('input', calculateInitialTotalHours);
        });

        calculateInitialTotalHours();
    }

    // Subject Hours Form Logic
    const subjectHoursForm = document.getElementById('subjectHoursForm');
    if (subjectHoursForm) {
        const hourInputs = document.querySelectorAll('.subject-hour');
        const totalEnteredHoursSpan = document.getElementById('totalEnteredHours');
        const generateButton = document.getElementById('generateButton');
        const totalHoursAlert = document.getElementById('totalHoursAlert');
        const totalHoursForWeek = parseInt(document.querySelector('[name="TotalHoursForWeek"]').value);

        function calculateTotalEnteredHours() {
            let total = 0;
            hourInputs.forEach(input => {
                total += parseInt(input.value) || 0;
            });

            totalEnteredHoursSpan.textContent = total;

            document.querySelectorAll('.remaining-hours').forEach(span => {
                const input = span.closest('tr').querySelector('.subject-hour');
                const hours = parseInt(input.value) || 0;
                span.textContent = totalHoursForWeek - (total - hours);
            });

            const isValid = total === totalHoursForWeek;
            generateButton.disabled = !isValid;

            totalHoursAlert.classList.remove('alert-success', 'alert-danger', 'alert-warning');
            if (total > totalHoursForWeek) {
                totalHoursAlert.classList.add('alert-danger');
            } else if (total === totalHoursForWeek) {
                totalHoursAlert.classList.add('alert-success');
            } else {
                totalHoursAlert.classList.add('alert-warning');
            }
        }

        hourInputs.forEach(input => {
            input.addEventListener('input', calculateTotalEnteredHours);
        });

        calculateTotalEnteredHours();
    }
}); 