const dates = [
    {
        year: new Date().getFullYear(),
        month: new Date().getMonth() + 1,
        ok: true
    },
    {
        year: new Date().getFullYear() + 1,
        month: new Date().getMonth() + 1,
        ok: false
    }
];

const currentDate = dates.shift();

pm.environment.set("[GET]-Use of the app-Dates", dates);
pm.environment.set("[GET]-Use of the app-Current date", currentDate);
pm.environment.set("[GET]-Use of the app-Year", currentDate.year);
pm.environment.set("[GET]-Use of the app-Month", currentDate.month);